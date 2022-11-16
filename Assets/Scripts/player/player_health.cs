using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_health : MonoBehaviour
{
    bool take_damage;
    public static int health;
    bool player_dead;
    float timer;
    float knock_time = 0f;
    public static int num_hearts;
    //Vector2 knockback;
    Rigidbody2D rb;
    float velocity;
    float speed;
    float mod;
    float pos_y;
    public static bool knock;
    bool bat_melee;

    // Start is called before the first frame update
    void Start()
    {
        take_damage = enemy_melee.melee;
        health = 100;
        player_dead = false;
        timer = 0f;
        num_hearts = 3;
        //knockback = new Vector3(11f, 0f, 0f);
        rb = GetComponent<Rigidbody2D>();

        speed = 10f;
        mod = .2f;
        velocity = 0f;// gameObject.transform.position.x + (speed * Time.deltaTime * mod);
        knock = false;
    }

    // Update is called once per frame
    void Update()
    {
        pos_y = transform.position.y;


        //Debug.Log("player_health = " + health);

        timer += Time.deltaTime;//timer wrong ???????

        take_damage = enemy_melee.melee;
        bat_melee = Behaviour.bat_melee;

        if (take_damage || bat_melee)// || bat_melee
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
            //rb.AddForce(knockback, ForceMode2D.Impulse);


        }

        if (health <= 0)
        {
            player_dead = true;
            //Debug.Log("Player is dead");
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

        if (collision.transform.CompareTag("bat"))
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

        if (collision.transform.CompareTag("bat"))
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

        if (collision.transform.CompareTag("bat"))
        {

            take_damage = false;
        }
    }




}
