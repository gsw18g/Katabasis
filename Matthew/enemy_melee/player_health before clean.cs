using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_health : MonoBehaviour
{
    bool en_melee;
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

    //[SerializeField] private Transform center;
    //[SerializeField] private float knockback_vel = 25f;
    //[SerializeField] private float knockback_time = 1f;
    //public GameObject zombie;

    // Start is called before the first frame update
    void Start()
    {
        en_melee = enemy_melee.melee;
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

        en_melee = enemy_melee.melee;
        bat_melee = Behaviour.bat_melee;

        if(en_melee || bat_melee)
        {
            player_damage();
        }

        /* if(knock)
         {
             if(knock_time <= 1f)
             {
                 Debug.Log("velocity ========== " + velocity);
                 //start adding to knocktime
                 knock_time += Time.deltaTime;

                 //start adding speed * time * mod every frame 
                 velocity += speed * Time.deltaTime * mod;
                 //substract vel from position.x every frame
                 rb.transform.position = new Vector3(transform.position.x - velocity, transform.position.y, 0f);
                 //gameObject.transform.position = new Vector3(transform.position.x - velocity, transform.position.y, 0f);
             }

             //if time == 2f stop adding vel and reset
             if (knock_time >= 1f)
             {
                 knock_time = 0f;
                 velocity = 0f;
                 knock = false;
             }
         }
         * */

      

    }

    void player_damage()
    {
        if(timer >= .5f)
        {
            knock = true;
           // knockback();
            health -= 34;
            timer = 0f;
            num_hearts -= 1;
            //rb.AddForce(knockback, ForceMode2D.Impulse);
            
            
        }



        if(health <= 0)
        {
            player_dead = true;
            //Debug.Log("Player is dead");
        }
    }

    public void knockback()
    {
        /*
         *  var dir = center.position - zombie.transform.position;
         rb.velocity = (Vector2)dir.normalized * knockback_vel;
         StartCoroutine(Unknockback());
         * */



        /*
         *  while(knock_time <= 2f)
         {
             Debug.Log("velocity ========== " + velocity);
             //start adding to knocktime
             knock_time += Time.deltaTime;

             //start adding speed * time * mod every frame 
             velocity += speed * Time.deltaTime * mod;
             //substract vel from position.x every frame
             //rb.transform.position = new Vector3(transform.position.x - velocity, pos_y, 0f);
             gameObject.transform.position = new Vector3(transform.position.x - velocity, transform.position.y, 0f);
         }

         //if time == 2f stop adding vel and reset
         if (knock_time >= 2f)
         {
             knock_time = 0f;
             velocity = 0f;
         }
         * */



    }

    /*private IEnumerator Unknockback()
    {
        yield return new WaitForSeconds(knockback_time);
    }
     * */



}
