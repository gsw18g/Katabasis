using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    public float speed;
    public float velocity;
    float pos_x;
    Rigidbody2D rb;
    float mod;
    Vector2 jump_height;
    bool ground;
    public bool slope_check;
    public Animator animator;
    bool facingLeft;
    bool facingRight;
    bool flip;
    bool knock = false;
    float knock_time = 0f;

    public GameObject zombie;
    public GameObject center;

    float knock_force = 5f;

    bool sinking = sink_check.sinking;

    bool bounce = false;
    float bounce_mag = -2f;
    Vector2 bounce_force = new Vector2(0f, 3f);

    // Start is called before the first frame update
    void Start()
    {
        mod = 1.5f;//.005
        speed = 2.0f;
        
        rb = GetComponent<Rigidbody2D>();
        //get players starting x and y pos
        pos_x = gameObject.transform.position.x;
        jump_height = new Vector2(0f,8f);//4f

        velocity = pos_x;//0f change the starting pos of player

        ground = check_ground.is_grounded;
        slope_check = check_ground.on_slope;


        facingLeft = false;
        facingRight = true;
        flip = false;
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
            if(facingLeft)
            {
                flip = !flip;
               
            }

            //walk = true;
            animator.SetBool("walk", true);
        }
        //move left
        else if(Input.GetKey(KeyCode.A) && !knock)
        {
            
            velocity = gameObject.transform.position.x + (-speed * Time.deltaTime * mod);
            if (facingRight)
            {
                flip = !flip;
               
            }
            //walk = true;
            animator.SetBool("walk", true);
        }
        else
        {
            //walk = false;
            animator.SetBool("walk", false);
        }




        if(flip && facingRight)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            facingRight = !facingRight;//facingright = false
            facingLeft = !facingLeft; // facingleft = true
            flip = !flip; //flip = false
        }

        if(flip && facingLeft)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            facingRight = !facingRight;//facingright = false
            facingLeft = !facingLeft; // facingleft = true
            flip = !flip; //flip = false
        }


       

        //if player is on the ground, and jump key pressed
        if(ground || slope_check || sinking)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                //jump
                
                rb.AddForce(jump_height, ForceMode2D.Impulse);
                animator.SetBool("jump", true);
                //Debug.Log("ground + jump");
            }
            


        }

        if(bounce)
        {
            rb.AddForce(bounce_force, ForceMode2D.Impulse);
            //rb.transform.position = new Vector3(transform.position.x, bounce_mag * Time.deltaTime, 0f);
            bounce = false;
        }
       
      
        if (knock && knock_time <= .1f)
        {
            var y_pos = transform.position.y;
                //Debug.Log("velocity ========== " + velocity);
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

            
                
                //substract vel from position.x every frame
                rb.transform.position = new Vector3(velocity, y_pos, 0f);//transform.position.y
                //gameObject.transform.position = new Vector3(transform.position.x - velocity, transform.position.y, 0f);

        }
        else
        {
            
            rb.transform.position = new Vector3(velocity, transform.position.y, 0f);
            //rb.transform.position = new Vector3(velocity, pos_y, 0f);
            knock_time = 0f;
            //velocity = 0f;
            player_health.knock = false;
        }

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
            bounce = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("horn"))
        {
            bounce = false;
        }
    }
}
