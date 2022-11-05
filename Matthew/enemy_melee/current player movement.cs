using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    public float speed = 2.0f;
    public float velocity;
    float pos_x;
    Rigidbody2D rb;
    float mod = 1.5f;//.005
    Vector2 jump_height = new Vector2(0f, 8f);
    bool ground;
    public bool slope_check;
    public Animator animator;
    bool facingLeft = false;
    bool facingRight = true;
    bool flip = false;
    bool knock = false;
    float knock_time = 0f;

    public GameObject zombie;
    public GameObject center;

    float knock_force = 5f;

    bool sinking = sink_check.sinking;

    bool bounce = false;
    float bounce_mag = 2f;
    Vector2 bounce_force = new Vector2(0f, 2f);
    bool reset_bounce = false;
    float bounce_time = 0f;

    int count = 0;

    Vector3 jump_right = new Vector3(8f, 8f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //get players starting x and y pos
        pos_x = gameObject.transform.position.x;
        velocity = pos_x;//0f change the starting pos of player



    }

    // Update is called once per frame
    void Update()
    {
        //move something smoothly mult by Time.deltaTime 

        ground = check_ground.is_grounded;
        slope_check = check_ground.on_slope;
        knock = player_health.knock;
        sinking = sink_check.sinking;


        //move right
        if (Input.GetKey(KeyCode.D) && !knock)
        {
            velocity = gameObject.transform.position.x + (speed * Time.deltaTime * mod);
            //velocity = 2f;
            if (facingLeft)
            {
                flip = !flip;

            }

            //set walk animation to true
            animator.SetBool("walk", true);


            Debug.Log("velocity in update = " + velocity);
            movement(velocity);
        }
        //move left
        else if (Input.GetKey(KeyCode.A) && !knock)
        {

            velocity = gameObject.transform.position.x + (-speed * Time.deltaTime * mod);
            if (facingRight)
            {
                flip = !flip;

            }
            //set walk animation to true
            animator.SetBool("walk", true);

            movement(velocity);
        }
        else
        {
            //set walk animation to false
            animator.SetBool("walk", false);
        }



        //if player is on the ground, and jump key pressed
        if (ground || slope_check || sinking)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                //jump
                
                rb.AddForce(jump_height, ForceMode2D.Impulse);
                animator.SetBool("jump", true);
                //Debug.Log("ground + jump");
            }///////////////////////////////////////////////////////////////
            else if(Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.D))
            {
                Debug.Log("space and D");
                rb.AddForce(jump_right, ForceMode2D.Impulse);
                animator.SetBool("jump", true);
            }

        }

        

        if (knock && knock_time <= .1f)
        {
            //save player pos
            var y_pos = transform.position.y;
                //start adding to knocktime
                knock_time += Time.deltaTime;
            if(GameObject.FindGameObjectWithTag("enemy_melee") != null)
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

                
                rb.transform.position = new Vector3(velocity, y_pos, 0f);//transform.position.y
                //substract vel from position.x every frame
               //gameObject.transform.position = new Vector3(transform.position.x - velocity, transform.position.y, 0f);

        }
        else if (bounce)
        {

            bounce_time += Time.deltaTime * 10;
            var player_y = transform.position.y;
            var rand = Random.Range(-100f, 100f);
            rb.velocity = new Vector3(8f, 8f, 0f);

            bounce = false;

        }
        else if(ground && Input.GetKey(KeyCode.D))/////////////////////////////////added
        {
            
            ///***************************rb.velocity = new Vector2(3f, 0f);*******************
                    //rb.transform.position = new Vector3(velocity, transform.position.y, 0f);
            //rb.transform.position = new Vector3(velocity, pos_y, 0f);
            knock_time = 0f;
            //velocity = 0f;
            player_health.knock = false;
        }
        else
        {
            //******************************rb.velocity = new Vector2(0f, rb.velocity.y);
        }

        //check if player stab
        if(Input.GetMouseButtonDown(0))
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
            bounce = false;
            
        }
    }

    void movement(float vel)
    {
        count++;

        //flip player sprite right
        if (flip && facingRight)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            facingRight = !facingRight;//facingright = false
            facingLeft = !facingLeft; // facingleft = true
            flip = !flip; //flip = false
        }
        //flip player sprite left
        if (flip && facingLeft)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            facingRight = !facingRight;//facingright = false
            facingLeft = !facingLeft; // facingleft = true
            flip = !flip; //flip = false
        }

        

        rb.transform.position = new Vector3(vel, transform.position.y, 0f);
        knock_time = 0f;
        player_health.knock = false;
        //rb.velocity = new Vector2(3f, 0f);
        Debug.Log("movement() vel =" + vel);
        
    }

    void jump()
    {

    }
}
