using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
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
    public bool on_slope;
    public bool hypno = false;
    public char Dir;
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
    float bounce_mag_y = .05f;//.025
    float bounce_mag_x = .05f;
    bool bounce_right = false;

    Vector3 attacking_enemy;

    bool stop_boat = false;

    public bool on_boat = check_ground.on_boat;
    // Start is called before the first frame update
    void Start()
    {
        mod = 1.5f;//.005
        speed = 5.0f;

        rb = GetComponent<Rigidbody2D>();
        //get players starting x and y pos
        pos_x = gameObject.transform.position.x;
        pos_y = gameObject.transform.position.y;
        //jump height
        jump_height = new Vector2(0f, 8.5f);//8//4f
        velocity = pos_x;//0f change the starting pos of player

    }

    // Update is called once per frame
    void Update()
    {
        ground = check_ground.is_grounded;
        on_slope = slope_check.on_slope;
        knock = player_health.knock;
        sinking = sink_check.sinking;
        on_boat = check_ground.on_boat;
        attacking_enemy = player_health.attacking_enemy;
        stop_boat = charon.stop;

        //continuously get y coord to do jump
        pos_y = gameObject.transform.position.y;

        //movement and idle animation

        if(hypno)
        {
            //move right
            if (Dir=='R' && !knock)
            {
                prev = 'a';
                velocity = gameObject.transform.position.x + (speed * Time.deltaTime * mod);
                animator.SetBool("walk", true);

                flip_player();
            }
            //move left
            else if (Dir=='L' && !knock)
            {
                prev = 'd';
                velocity = gameObject.transform.position.x + (-speed * Time.deltaTime * mod);
                animator.SetBool("walk", true);
                //movement(velocity);
                flip_player();
            }
            //idle animation
            else
            {

                animator.SetBool("walk", false);
            }

        }
        else
        {
            //move right
            if (Input.GetKey(KeyCode.D) && !knock)
            {
                prev = 'a';
                velocity = gameObject.transform.position.x + (speed * Time.deltaTime * mod);
                animator.SetBool("walk", true);

                flip_player();
            }
            //move left
            else if (Input.GetKey(KeyCode.A) && !knock)
            {
                prev = 'd';
                velocity = gameObject.transform.position.x + (-speed * Time.deltaTime * mod);
                animator.SetBool("walk", true);
                //movement(velocity);
                flip_player();
            }
            //idle animation
            else
            {

                animator.SetBool("walk", false);
            }

            //if player is on the ground, and jump key pressed
            if (ground || sinking || on_slope)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    //jump

                    rb.AddForce(jump_height, ForceMode2D.Impulse);
                    animator.SetBool("jump", true);
                    //Debug.Log("ground + jump");
                }
            }
        }
        

        //knock player back if colliding with enemy
        if (knock && knock_time <= .1f)
        {
            var y_pos = transform.position.y;
            //start adding to knocktime
            knock_time += Time.deltaTime;
            if (GameObject.FindGameObjectWithTag("enemy_melee") != null)
            {
                if (center.transform.position.x - attacking_enemy.x  < 0)//zombie.transform.position.x
                {
                    //start subtracting knock_force * time * mod every frame to knock player left
                    velocity -= (knock_force * Time.deltaTime * mod);
                }
                else
                {
                    //start adding knock_force * time * mod every frame to knock player right
                    velocity += (knock_force * Time.deltaTime * mod);
                }
            }

            //set new velocity every frame
            rb.transform.position = new Vector3(velocity, y_pos, 0f);//transform.position.y

        }
        //bounce player in air if colliding with horn
        else if(bounce)
        {
            bounce_time += Time.deltaTime;
            if(bounce_time <= .2f)
            {
               //bounce right
                if(bounce_right)
                {
                    rb.transform.position += new Vector3(bounce_mag_x, bounce_mag_y, 0f);
                }
                //bounce_left
                else
                {
                    rb.transform.position += new Vector3(-bounce_mag_x, bounce_mag_y, 0f);
                }
                
            }
            //reset bounce
            else
            {
                bounce_time = 0f;
                bounce = false;
                velocity = rb.transform.position.x;
                bounce_right = false;
            }
            
        }
        else if(on_boat && !stop_boat)
        {
            //add the boats velocity to the player velocity
            velocity += Time.deltaTime * 2.5f;
            movement(velocity);
        }
        //else move player (on ground)
        else
        {
            //move player
            movement(velocity);
        }

        //if left mouse pressed play stab animation
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("stab", true);
        }

 
    }//end update

    public void reset_stab()
    {
        //Debug.Log("reset stab = false");
        animator.SetBool("stab", false);
        SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.playerStab);
    }


    public void reset_jump()
    {

        animator.SetBool("jump", false);
    }

    //move player
    void movement(float vel)
    {
        rb.transform.position = new Vector3(vel, transform.position.y, 0f);
        knock_time = 0f;
        player_health.knock = false;
    }

    void flip_player()
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
            //get random value 0 or 1
            bounce = true;
            var rand = Random.Range(0, 2);
          
            if (rand == 0)
            {
                bounce_right = true;
            }
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
