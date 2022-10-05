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

    float x_onslope;
    float y_onslope;
   
   
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

    }

    // Update is called once per frame
    void Update()
    {
        //move something smoothly mult by Time.deltaTime 

        ground = check_ground.is_grounded;
        slope_check = check_ground.on_slope;
        slope_coord = check_ground.coord;

        //continuously get y coord to do jump
        pos_y = gameObject.transform.position.y;

        //move right
        if (Input.GetKey(KeyCode.D))
        {
            velocity = gameObject.transform.position.x + (speed * Time.deltaTime * mod);
             
        }

        //move left
        if(Input.GetKey(KeyCode.A))
        {
            velocity = gameObject.transform.position.x + (-speed * Time.deltaTime * mod);
            
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
       
        if(slope_check)
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





    }




}