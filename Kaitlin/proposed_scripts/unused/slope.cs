using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slope : MonoBehaviour
{
    public static Vector3 coord;
    //public static bool on_slope;

    // Start is called before the first frame update
    void Start()
    {
        coord = new Vector3(0f, 0f, 0f);
        //on_slope = false;
    }

    // Update is called once per frame
    void Update()
    {
        coord = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0f);
        //Debug.Log("coord = " + coord);
    }

    /*
     * private void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.transform.CompareTag("slope"))
        {
            on_slope = true;
            coord = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0f);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        

        if (collision.transform.CompareTag("slope"))
        {
            on_slope = true;
            coord = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0f);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
       

        if (collision.transform.CompareTag("slope"))
        {
            on_slope = false;

        }
    }
     * */
}
