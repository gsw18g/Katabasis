using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball_hor : MonoBehaviour
{
    float timer = 0f;

    //GameObject player;
    Rigidbody2D rb;
    bool stop_seek = false;
    Vector3 player_pos;

    public GameObject hades;
    public GameObject player;

    float pos_y;

    public bool vert = false;

    int dir;

    float speed = 20f;//25
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //player = GameObject.FindGameObjectWithTag("Player");
        //player_pos = player.transform.position;

        pos_y = transform.position.y;

        player = GameObject.FindGameObjectWithTag("Player");
        hades = GameObject.FindGameObjectWithTag("hades");

        if (player != null)
        {
            //player_pos = player.transform.position;
            //Debug.Log("hades - player = " + (hades.transform.position.x - player.transform.position.x));

            if (hades.transform.position.x - player.transform.position.x > 0)
            {
                dir = -1;
                
            }
            else
            {
                dir = 1;
                
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        rb.transform.position = new Vector3(gameObject.transform.position.x + dir * Time.deltaTime * speed, pos_y, 0f);

        //horizontal fireball

        //if(!stop_seek)
        //{
        //player = GameObject.FindGameObjectWithTag("Player");
        // Move our position a step closer to the target.
        ////////////////var step = speed * Time.deltaTime;
        // calculate distance to move
        ////////////////transform.position = Vector3.MoveTowards(transform.position, player_pos, step);//transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
        //apply move toward player to rigidbody
        /////////rb.transform.position = transform.position;
        //}
        //else
        //{
        // Debug.Log("stop seeking");
        //}



        if (timer > 10f)
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

        if (collision.CompareTag("player_body"))
        {
            player_health.fireball_damage = true;
            
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("fireball_radius"))
        {
            stop_seek = true;
        }

        if (collision.CompareTag("player_body"))
        {
            player_health.fireball_damage = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("fireball_radius"))
        {
            stop_seek = false;
        }

        if (collision.CompareTag("player_body"))
        {
            player_health.fireball_damage = false;
            Destroy(gameObject);
        }
    }
}
