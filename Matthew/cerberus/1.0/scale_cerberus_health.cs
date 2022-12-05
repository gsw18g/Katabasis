using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scale_cerberus_health : MonoBehaviour
{
    int health;
    float scale;

    //public GameObject enemy;
    //enemy_melee zombie;

    // Start is called before the first frame update
    void Start()
    {
        

        // health = enemy_melee.health;
        scale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        health = cerberus_weak_point.health;//cerberus.health;
        //health = enemy_melee.health;

        if (health < 200f)
        {
            scale = health / 200f;
            gameObject.transform.localScale = new Vector3(scale, 1.39f, 1f);//health / 100

        }

    }
}
