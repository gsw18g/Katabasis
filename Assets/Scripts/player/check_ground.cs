using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check_ground : MonoBehaviour
{
    public static bool is_grounded;

    // Start is called before the first frame update
    void Start()
    {
        is_grounded = false;

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

}
