using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class river_styx : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player_health.health = 0;
            collision.GetComponent<player_health>().player_damage();
        }
            
            
    }

    protected void OnTriggerStay2D(Collider2D collision)
    {
        /*
         * if (collision.tag == "Player")
            collision.GetComponent<player_health>().player_damage();
         * */
    }
}
