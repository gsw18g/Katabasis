using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    public float speed;
    public float velocity;
    float pos_y;
    float pos_x;
    Rigidbody2D rb;
    float mod;
    Vector2 jump_height;
    bool ground;
    public bool slope_check;

    public Animator animator;

    bool knock = false;
    float knock_time = 0f;

    public GameObject zombie;
    public GameObject center;

    float knock_force = 5f;
    bool sinking = sink_check.sinking;
    char prev;
    bool bounce = false;
    float bounce_time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        mod = 1.5f;//.005
        speed = 2.0f;

        rb = GetComponent<Rigidbody2D>();
        //get players starting x and y pos
        pos_x = gameObject.transform.position.x;
        pos_y = gameObject.transform.position.y;
        jump_height = new Vector2(0f, 8f);//4f

        velocity = pos_x;//0f change the starting pos of player

        ground = check_ground.is_grounded;
        slope_check = check_ground.on_slope;

    }

    // Update is called once per frame
    void Update()
    {
        //move something smoothly mult by Time.deltaTime 
        ground = check_ground.is_grounded;
        slope_check = check_ground.on_slope;
        knock = player_health.knock;
        sinking = sink_check.sinking;

        //continuously get y coord to do jump
        pos_y = gameObject.transform.position.y;

        //move right
        if (Input.GetKey(KeyCode.D) && !knock)
        {
            prev = 'a';
            velocity = gameObject.transform.position.x + (speed * Time.deltaTime * mod);
            
            //walk = true;
            animator.SetBool("walk", true);
            
            flip_player(0);
        }
        //move left
        else if (Input.GetKey(KeyCode.A) && !knock)
        {
            prev = 'd';
            velocity = gameObject.transform.position.x + (-speed * Time.deltaTime * mod);
            
            //walk = true;
            animator.SetBool("walk", true);
            //movement(velocity);
            flip_player(0);
        }
        else
        {
            //walk = false;
            animator.SetBool("walk", false);
        }

        //if player is on the ground, and jump key pressed
        if (ground || slope_check || sinking)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //jump

                rb.AddForce(jump_height, ForceMode2D.Impulse);
                animator.SetBool("jump", true);
                //Debug.Log("ground + jump");
            }
        }

        if (knock && knock_time <= .1f)
        {
            var y_pos = transform.position.y;
            //start adding to knocktime
            knock_time += Time.deltaTime;
            if (GameObject.FindGameObjectWithTag("enemy_melee") != null)
            {
                if (center.transform.position.x - zombie.transform.position.x < 0)
                {
                    //start adding speed * time * mod every frame 
                    velocity -= (knock_force * Time.deltaTime * mod);
                }
                else
                {
                    //start adding speed * time * mod every frame 
                    velocity += (knock_force * Time.deltaTime * mod);
                }
            }

            //substract vel from position.x every frame
            rb.transform.position = new Vector3(velocity, y_pos, 0f);//transform.position.y

        }
        else //if(bounce) this works correctly without the velocity bug 
        {
            bounce_time += Time.deltaTime;
            if(bounce_time <= .5f)
            {
                rb.transform.position += new Vector3(.1f, .1f, 0f);
            }
            else
            {
                bounce_time = 0f;
                bounce = false;
                velocity = rb.transform.position.x;
            }

            
        }
        else if(ground)
        {
            //move player
            movement(velocity);
        }

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("stab", true);
        }

 
    }//update


    public void reset_stab()
    {
        Debug.Log("reset stab = false");
        animator.SetBool("stab", false);
    }


    public void reset_jump()
    {

        animator.SetBool("jump", false);
    }


    void movement(float vel)
    {
        rb.transform.position = new Vector3(vel, transform.position.y, 0f);
        knock_time = 0f;
        player_health.knock = false;
    }

    void flip_player(int deg)
    {
        if(prev == 'a')
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if(prev == 'd')
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("horn"))
        {
            bounce = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("horn"))
        {
            //          bounce = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("horn"))
        {
            //bounce = false;
            

        }
    }
}
