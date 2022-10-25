using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class remove_heart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player_health.num_hearts == 2)
        {
            Destroy(GameObject.FindWithTag("heart3"));
        }

        if (player_health.num_hearts == 1)
        {
            Destroy(GameObject.FindWithTag("heart2"));
        }

        if (player_health.num_hearts == 0)
        {
            Destroy(GameObject.FindWithTag("heart1"));
        }
    }
}
