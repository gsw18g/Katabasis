using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check_ground : MonoBehaviour
{
    public static bool is_grounded;
    public static bool on_slope;
    public static Vector3 coord;

    float dist_to_sink = 1f;
    float sink_y = 0f;

    // Start is called before the first frame update
    void Start()
    {
        is_grounded = false;
        on_slope = false;
        coord = new Vector3(0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y - sink_y > dist_to_sink)
        {
            is_grounded = true;
        }
    }

    /*
     *  private void OnTriggerEnter2D(Collider2D collision)
     {
         if (collision.transform.CompareTag("ground"))
         {
             is_grounded = true;
         }
     }

     private void OnTriggerStay2D(Collider2D collision)
     {
         if (collision.transform.CompareTag("ground"))
         {
             if (collision.transform.CompareTag("ground"))
             {
                 is_grounded = true;
             }
         }
     }

     private void OnTriggerExit2D(Collider2D collision)
     {
         if (collision.transform.CompareTag("ground"))
         {
             is_grounded = false;
         }
     }
     * */

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("ground") || collision.transform.CompareTag("sink"))
        {
            is_grounded = true;
        }

        if(collision.transform.CompareTag("slope"))
        {
            on_slope = true;
            coord = new Vector3(collision.transform.position.x, collision.transform.position.y, 0f);
        }

        if(collision.transform.CompareTag("sink"))
        {
            
            
            sink_y = collision.transform.gameObject.transform.position.y;
            
        }
       
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("ground") || collision.transform.CompareTag("sink"))
        {
            is_grounded = true;
        }

        if (collision.transform.CompareTag("slope"))
        {
            on_slope = true;
            coord = new Vector3(collision.transform.position.x, collision.transform.position.y, 0f);
        }


        if (collision.transform.CompareTag("sink"))
        {


            sink_y = collision.transform.gameObject.transform.position.y;
            if (gameObject.transform.position.y - sink_y > dist_to_sink)
            {
                is_grounded = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("ground") || collision.transform.CompareTag("sink"))
        {
            is_grounded = false;
        }

        if (collision.transform.CompareTag("slope"))
        {
            on_slope = false;
            
        }
    }

}
