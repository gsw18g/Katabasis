using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_health : MonoBehaviour
{
    bool en_melee;
    public static int health;
    bool player_dead;
    float timer;
    public static int num_hearts;

    // Start is called before the first frame update
    void Start()
    {
        en_melee = enemy_melee.melee;
        health = 100;
        player_dead = false;
        timer = 0f;
        num_hearts = 3;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("player_health = " + health);
        timer += Time.deltaTime;

        en_melee = enemy_melee.melee;

        if(en_melee)
        {
            player_damage();
        }
    }

    void player_damage()
    {
        if(timer >= 2f)
        {
            health -= 34;
            timer = 0f;
            num_hearts -= 1;
        }



        if(health <= 0)
        {
            player_dead = true;
            Debug.Log("Player is dead");
        }
    }




}
