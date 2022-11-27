// camera_level.cs: Centers and moves camera with player
// written by: Matthew Kaplan
// TO DO: This does the same thing as camera_level2 except one value is changed, is there a better way to implement?

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
    public float y_offset = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        the_player = player.GetComponent<player_movement>();
        x_pos = gameObject.transform.position.x;
        y_pos = gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(x_pos + the_player.transform.position.x + offset, y_pos + the_player.transform.position.y + y_offset, 0f);
    }
}
