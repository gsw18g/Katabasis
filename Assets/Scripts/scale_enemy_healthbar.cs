using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scale_enemy_healthbar : MonoBehaviour
{
    int health;
    float scale;
    // Start is called before the first frame update
    void Start()
    {
        health = enemy_melee.health;
        scale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        health = enemy_melee.health;

        if(health < 100)
        {
            scale = health / 100f;
            gameObject.transform.localScale = new Vector3(scale, 1f, 1f);//health / 100

        }
       
    }
}
