using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
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
    public static bool fireball_damage = false;
    private Animator anim;

    bool cerberus_melee = false;



    public static Vector3 attacking_enemy;

    private UIManager UIManager;

    // Start is called before the first frame update
    void Start()
    {
        //take_damage = enemy_melee.melee;
        health = 100;
        player_dead = false;
        timer = 0f;
        num_hearts = 5;
        UIManager = FindObjectOfType<UIManager>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;//timer wrong ???????

        //take_damage = enemy_melee.melee;
        bat_melee = Behaviour.bat_melee;

        if (take_damage || bat_melee || fireball_damage || cerberus_melee)
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
            health -= 20;
            timer = 0f;
            num_hearts -= 1;
            SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.playerHurt);
        }

        if (health <= 0)
        {
            SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.playerDeath);
            player_dead = true;
            anim.SetTrigger("Dead");
            if(!weak_point.win_game)
            {
                UIManager.GameOver();
            }
            
        }
    }

    public void end_death_anim()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("bat"))
        {

            bat_melee = true;
            //Debug.Log("bat coord = " + collision.transform.position);
            attacking_enemy = collision.transform.position;
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
            attacking_enemy = collision.transform.position;
        }

        if (collision.transform.CompareTag("cerberus"))
        {

            cerberus_melee = true;
            
            attacking_enemy = collision.transform.position;
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

        if (collision.transform.CompareTag("cerberus"))
        {

            cerberus_melee = false;
            

        }

    }




}
