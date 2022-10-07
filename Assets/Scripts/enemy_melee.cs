using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_melee : MonoBehaviour
{
    player_movement player_pos;
    public GameObject player;
    float velocity;
    float speed;
    float mod;
    Rigidbody2D rb;
    float pos_y;
    bool sword_hit;
    bool down_swing;
    bool mouseclick;
    float z_rot;
    //bool sword_collider_hit;

    // Start is called before the first frame update
    void Start()
    {
        player_pos = player.GetComponent<player_movement>();
        velocity = 0f;
        mod = 0f;
        speed = 1f;
        pos_y = 0f;
        rb = GetComponent<Rigidbody2D>();
        sword_hit = sword_check.hit_melee_enemy;
        down_swing = sword.downswing;
        mouseclick = false;
        z_rot = sword.z_rot;
        //down_swing = sword_collider.sword_collider_hit;
    }

    // Update is called once per frame
    void Update()
    {
        // Move our position a step closer to the target.
        var step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, player_pos.transform.position, step);
        rb.transform.position = transform.position;

        sword_hit = sword_check.hit_melee_enemy;
        down_swing = sword.downswing;
        //down_swing = sword_collider.sword_collider_hit;

        Debug.Log("sword_hit = " + sword_hit);
        Debug.Log("downswing" + down_swing);


        /*
         * if(Input.GetMouseButton(0))
        {
            mouseclick = true;
        }
         * */

        /*
         * 
         *  if (sword_hit && down_swing && Input.GetMouseButton(0))
         {
             down_swing = false;
             Destroy(gameObject);
         }
         * */
        z_rot = sword.z_rot;
        Debug.Log("z_rot==============" + z_rot);

        if (Input.GetMouseButton(0) && sword_hit && z_rot < -10 && z_rot > -19)
        {
            down_swing = false;
            Destroy(gameObject);
        }

        //pos_y = gameObject.transform.position.y;
        //velocity = gameObject.transform.position.x + (speed * Time.deltaTime * mod);

        //rb.transform.position = new Vector3(velocity, pos_y, 0f);
    }
}
