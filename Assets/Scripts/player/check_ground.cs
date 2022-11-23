using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check_ground : MonoBehaviour
{
    public static bool is_grounded = false;
    public static bool on_boat = false;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("ground"))
        {
            is_grounded = true;
        }

        

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("ground"))
        {
            is_grounded = true;
        }

        

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("ground"))
        {
            is_grounded = false;
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("boat"))
        {
            on_boat = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("boat"))
        {
            on_boat = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("boat"))
        {
            on_boat = false;
        }
    }

}
