// sinking_platform.cs: sink platform if collision with player detected
// written by: Matthew Kaplan

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sinking_platform : MonoBehaviour
{
    Rigidbody2D rb;
    public bool sink_ground = false;
    public float mod = 20f;//4//.01

    float timer = 0f;

    float pos_y;

    // Start is called before the first frame update
    void Start()
    {
        pos_y = transform.position.y;
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
    }

    // sink the platform if colliding with player
    void Update()
    {
        if(sink_ground)
        {
            timer += Time.deltaTime;

            if(timer >= 0f)
            {
                rb.isKinematic = false;
                timer = 0f;
            }            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            Debug.Log("sink_ground = true");
            sink_ground = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("sink_ground = true");
            sink_ground = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("sink_ground = false");
            sink_ground = false;
        }
    }
}
