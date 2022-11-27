// sink_check.cs: check to sink platform if collision with player detected?
// written by: Matthew Kaplan

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sink_check : MonoBehaviour
{
    public static bool sinking = false;

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
        if (collision.transform.CompareTag("sink"))
        {
            sinking = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("sink"))
        {
            sinking = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("sink"))
        {
            sinking = false;
        }
    }   
}
