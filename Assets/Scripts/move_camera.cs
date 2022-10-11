using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_camera : MonoBehaviour
{
    public GameObject player;
    player_movement the_player;
    float x_pos;
    float y_pos;
    //offset camera to center on player
    float offset = 0f;//8.39
    // Start is called before the first frame update
    void Start()
    {
        the_player = player.GetComponent<player_movement>();
        //x_pos = the_player.transform.position.x;
        x_pos = gameObject.transform.position.x;
        y_pos = gameObject.transform.position.y;
        //y_pos = the_player.transform.position.y;
       
    }

    // Update is called once per frame
    void Update()
    {
        //x_pos = gameObject.transform.position.x;

        gameObject.transform.position = new Vector3(x_pos + the_player.velocity + offset, y_pos, 0f);
        //gameObject.transform.position = new Vector3(x_pos, y_pos, 0f);


    }
}
