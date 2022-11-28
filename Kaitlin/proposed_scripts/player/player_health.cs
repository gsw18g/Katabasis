// player_health.cs: Sets player health, deducts health if collision with enemy detected and senses if player is dead
// written by: Matthew Kaplan
// reviewed by: Kaitlin Tran

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_health : MonoBehaviour
{
    bool take_damage;
    public static int health;
    bool player_dead;
    float timer;
    public static int num_hearts;
    public static bool knock = false;
    bool bat_melee;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        player_dead = false;
        timer = 0f;
        num_hearts = 3;
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;//timer wrong ???????
        bat_melee = Behaviour.bat_melee;

        if (take_damage || bat_melee)
        {
            player_damage();
        }
    }

   public void player_damage()
    {
        if (timer >= .5f)
        {
            //set bool to use in player movement
            knock = true;
            health -= 34;
            timer = 0f;
            num_hearts -= 1;
        }

        if (health <= 0)
        {
            player_dead = true;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("bat"))
        {
            bat_melee = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("bat"))
        {
            bat_melee = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("bat"))
        {
            bat_melee = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("enemy_melee"))
        {
            take_damage = true;
        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("enemy_melee"))
        {
            take_damage = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("enemy_melee"))
        {
            take_damage = false;
        }
    }
}
