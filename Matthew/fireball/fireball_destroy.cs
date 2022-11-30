using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball_destroy : MonoBehaviour
{
    float timer = 0f;

    GameObject player;
    Rigidbody2D rb;
    bool stop_seek = false;
    Vector3 player_pos;

    float speed = 25f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        player_pos = player.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
       
        timer += Time.deltaTime;


        
        //if(!stop_seek)
        //{
            //player = GameObject.FindGameObjectWithTag("Player");
            // Move our position a step closer to the target.
            var step = speed * Time.deltaTime;
            // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, player_pos, step);//transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
        //apply move toward player to rigidbody
        rb.transform.position = transform.position;
        //}
        //else
        //{
           // Debug.Log("stop seeking");
        //}
        


        if (timer > 4f)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("fireball_radius"))
        {
            stop_seek = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("fireball_radius"))
        {
            stop_seek = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("fireball_radius"))
        {
            stop_seek = false;
        }
    }
}
