using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horn : MonoBehaviour
{
    bool bounce = false;
    public bool wft;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bounce)
        {
            //do bounce

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            bounce = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            bounce = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            bounce = false;
        }
    }
}
