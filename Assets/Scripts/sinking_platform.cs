using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sinking_platform : MonoBehaviour
{

    public bool sink_ground = false;
    public float mod = 2f;//4

    float pos_y;

    // Start is called before the first frame update
    void Start()
    {
        pos_y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(sink_ground)
        {
            //pos_y -= Time.deltaTime * mod;//Time.deltaTime //.001
            gameObject.transform.position -= new Vector3(0f, Time.deltaTime * mod, 0f);
        }

        //gameObject.transform.position = new Vector3(transform.position.x, pos_y, 0f);
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
