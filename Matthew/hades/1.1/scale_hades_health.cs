using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scale_hades_health : MonoBehaviour
{
    int health;
    float scale;

    //public GameObject enemy;
    //weak_point boss;

    float total_health = 300f;

    // Start is called before the first frame update
    void Start()
    {
        //boss = enemy.GetComponent<weak_point>();

        // health = enemy_melee.health;
        scale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        //health = boss.health;
        //health = enemy_melee.health;
        health = weak_point.health;

        if (health < total_health)
        {
            scale = health / total_health;
            gameObject.transform.localScale = new Vector3(scale, 1f, 1f);//health / 100

        }

    }
}
