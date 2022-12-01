using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charon : MonoBehaviour
{
    Rigidbody2D rb;
    float mod = 1.5f;
    float pos_y;

    public static bool stop = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pos_y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(!stop)
        {
            rb.transform.position = new Vector3(gameObject.transform.position.x + Time.deltaTime * mod, pos_y, 0f);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("stop_boat"))
        {
            stop = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("stop_boat"))
        {
            stop = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("stop_boat"))
        {
            stop = false;
        }
    }
}
