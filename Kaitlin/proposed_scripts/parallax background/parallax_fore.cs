// parallax_fore.cs: Move foremost layer of background at certain rate for illusion of depth
// written by: Matthew Kaplan
// reviewed by: Kaitlin Tran

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
        speed = .5f;//.5 // .6
        the_player = player.GetComponent<player_movement>();
        x_pos = gameObject.transform.position.x;
        y_pos = gameObject.transform.position.y;
        offset = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        vel = the_player.transform.position.x;
        gameObject.transform.position = new Vector3((-vel * speed) + offset, y_pos, 0f);
    }
}
