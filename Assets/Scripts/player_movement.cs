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
    bool slope_check;
    Vector3 slope_coord;

    bool facingLeft;
    bool facingRight;
    bool flip;

    float x_onslope;
    float y_onslope;

    bool knock = false;
    float knock_time = 0f;

    /*[SerializeField] private Transform center;
    [SerializeField] private float knockback_vel = 10f;
    [SerializeField] private float knockback_time = 1f;

     * */


    // Start is called before the first frame update
    void Start()
    {
        mod = 1.5f;//.005
        speed = 1.0f;
        
        rb = GetComponent<Rigidbody2D>();
        //get players starting x and y pos
        pos_x = gameObject.transform.position.x;
        pos_y = gameObject.transform.position.y;
        jump_height = new Vector2(0f,4f);//4f

        velocity = pos_x;//0f change the starting pos of player

        ground = check_ground.is_grounded;
        slope_check = check_ground.on_slope;
        slope_coord = check_ground.coord;

        x_onslope = 0f;
        y_onslope = 0f;

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
        slope_coord = check_ground.coord;
        knock = player_health.knock;

        //continuously get y coord to do jump
        pos_y = gameObject.transform.position.y;

        //move right
        if (Input.GetKey(KeyCode.D))
        {
            velocity = gameObject.transform.position.x + (speed * Time.deltaTime * mod);
            if(facingLeft)
            {
                flip = !flip;
                //facingRight = !facingRight;
                //facingLeft = !facingLeft;
                //transform.eulerAngles = new Vector3(0, 180, 0);
            }
             
        }

        //move left
        if(Input.GetKey(KeyCode.A))
        {
            
            velocity = gameObject.transform.position.x + (-speed * Time.deltaTime * mod);
            if (facingRight)
            {
                flip = !flip;
               // facingRight = !facingRight;
                //facingLeft = !facingLeft;
                //transform.eulerAngles = new Vector3(0, 0, 0);
            }

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
        if(ground || slope_check)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                //jump
                
                rb.AddForce(jump_height, ForceMode2D.Impulse);
                Debug.Log("ground + jump");
            }
           
        }

        /*
         * if(slope_check)
        {
            Debug.Log("on slope");
            Debug.Log("slope_coord =" + slope_coord);

            x_onslope = gameObject.transform.position.x;
            y_onslope = gameObject.transform.position.y;

           rb.transform.position = new Vector3(x_onslope + (1.5f * Time.deltaTime), y_onslope - (1.5f * Time.deltaTime), 0f);


            //gameObject.transform.position = new Vector3(slope_coord.x, -slope_coord.x - 5.5f, 0f);
            //rb.transform.position = new Vector3(velocity,pos_y - (Time.deltaTime * 1.5f), 0f);// new Vector3(velocity,-(velocity + 6f), 0f);//pos_y - (10f * Time.deltaTime)
            //rb.transform.position = new Vector3(slope_coord.x, -slope_coord.x - 5.5f, 0f);

        }
        else
        {
            //apply to rb
            rb.transform.position = new Vector3(velocity, pos_y, 0f);
            //rb.transform.position = new Vector3(velocity, pos_y, 0f);
        }
         * */


        if(knock && knock_time <= 1f)
        {
            
                Debug.Log("velocity ========== " + velocity);
                //start adding to knocktime
                knock_time += Time.deltaTime;

                //start adding speed * time * mod every frame 
                velocity -= (speed * Time.deltaTime * mod);
                //substract vel from position.x every frame
                rb.transform.position = new Vector3(velocity, transform.position.y, 0f);
                //gameObject.transform.position = new Vector3(transform.position.x - velocity, transform.position.y, 0f);
            
            
            
               
            
          

            
        }
        else
        {
            rb.transform.position = new Vector3(velocity, pos_y, 0f);
            knock_time = 0f;
            //velocity = 0f;
            player_health.knock = false;
        }


        /* old function
         * if(knock)
        {
            if (knock_time <= 1f)
            {
                Debug.Log("velocity ========== " + velocity);
                //start adding to knocktime
                knock_time += Time.deltaTime;

                //start adding speed * time * mod every frame 
                velocity -= (speed * Time.deltaTime * mod);
                //substract vel from position.x every frame
                rb.transform.position = new Vector3(velocity, transform.position.y, 0f);
                //gameObject.transform.position = new Vector3(transform.position.x - velocity, transform.position.y, 0f);
            }
            else if (knock_time >= 1f)
            {
                knock_time = 0f;
                //velocity = 0f;
                player_health.knock = false;
            }
            {

            }

            
        }
        else
        {
            rb.transform.position = new Vector3(velocity, pos_y, 0f);
        }
         * */

        Debug.Log("knocktime ******** " + knock_time);




    }//update

    /*public void knockback()
    {
        var dir = center.position - transform.position;
        rb.velocity = (Vector2)dir.normalized * knockback_vel;
        StartCoroutine(Unknockback());
    }

    private IEnumerator Unknockback()
    {
        yield return new WaitForSeconds(knockback_time);
    }

     * */

}
