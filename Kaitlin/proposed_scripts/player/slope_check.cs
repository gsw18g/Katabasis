using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slope_check : MonoBehaviour
{
    public static bool on_slope = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //check if slope collison circle is colliding with a slope
        if (collision.transform.CompareTag("slope"))
        {
            on_slope = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //check if slope collison circle is colliding with a slope
        if (collision.transform.CompareTag("slope"))
        {
            on_slope = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //check if slope collison circle is colliding with a slope
        if (collision.transform.CompareTag("slope"))
        {
            on_slope = false;
        }
    }
}
