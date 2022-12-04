using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax_fore : MonoBehaviour
{
    public float speed;
    public GameObject player;
    player_movement the_player;
    float vel;
    float x_pos;
    float y_pos;
    float offset;
    // Start is called before the first frame update
    void Start()
    {
        speed = .15f;//.5 // .6
        the_player = player.GetComponent<player_movement>();
        x_pos = gameObject.transform.position.x;
        y_pos = gameObject.transform.position.y;
        //vel = gameObject.transform.position.x;
        offset = transform.position.x;


    }

    // Update is called once per frame
    void Update()
    {
        //vel = the_player.velocity;
        vel = the_player.transform.position.x;

        //vel = vel - (x_pos.transform.position.x * speed);
        //gameObject.transform.position = new Vector3(x_pos + (-vel * speed), y_pos, 0f);
        gameObject.transform.position = new Vector3((-vel * speed) + offset, y_pos, 0f);

        //Debug.Log("player vel = " + vel);
    }
}
