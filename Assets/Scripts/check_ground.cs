using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check_ground : MonoBehaviour
{
    public static bool is_grounded;
    public static bool on_slope;
    public static Vector3 coord;

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
        if (collision.transform.CompareTag("ground"))
        {
            is_grounded = true;
        }

        if(collision.transform.CompareTag("slope"))
        {
            on_slope = true;
            coord = new Vector3(collision.transform.position.x, collision.transform.position.y, 0f);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("ground"))
        {
            is_grounded = true;
        }

        if (collision.transform.CompareTag("slope"))
        {
            on_slope = true;
            coord = new Vector3(collision.transform.position.x, collision.transform.position.y, 0f);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("ground"))
        {
            is_grounded = false;
        }

        if (collision.transform.CompareTag("slope"))
        {
            on_slope = false;
            
        }
    }

}
