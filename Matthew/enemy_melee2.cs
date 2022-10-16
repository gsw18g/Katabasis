using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_melee : MonoBehaviour
{
    player_movement player_pos;
    public GameObject player;



    float speed;
    //float mod;
    Rigidbody2D rb;
    float pos_y;
    bool sword_hit;
    //public static int health;
    public static bool melee;

    int health = 100;
    

    [SerializeField] private Transform center;
    [SerializeField] private float knockbackvl=10f;
    [SerializeField] private float knockbacktime = 1f;


    // Start is called before the first frame update
    void Start()
    {
        //player_pos = player.GetComponent<player_movement>();

        player = GameObject.FindGameObjectWithTag("Player");


        //velocity = 0f;
        //mod = 0f;
        speed = 1f;
        pos_y = 0f;
        rb = GetComponent<Rigidbody2D>();
        sword_hit = sword_check.hit_melee_enemy;
        //down_swing = sword.downswing;
        //mouseclick = false;
        //z_rot = sword.z_rot;
        melee = false;
        //health = 100;
        //down_swing = sword_collider.sword_collider_hit;
    }

    // Update is called once per frame
    void Update()
    {


        // Move our position a step closer to the target.
        var step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
        //transform.position = Vector3.MoveTowards(transform.position, player_pos.transform.position, step);
        rb.transform.position = transform.position;

        sword_hit = sword_check.hit_melee_enemy;
        //down_swing = sword.downswing;
       
        
        //z_rot = sword.z_rot;
        //Debug.Log("z_rot==============" + z_rot);

        if(Input.GetMouseButtonDown(0) && sword_hit)// && down_swing z_rot < -10 && z_rot > -19
        {
            enemy_damage();
            //down_swing = false;
            //Destroy(gameObject);
        }

       // gameObject.transform.localScale = new Vector3(1 - (health / 100), 0f, 0f);
       
    }

    void enemy_damage_old()
    {
        
       
        if (health > 0)
        {
            health -= 34;
            knockback();
            //animator.SetBool("stab", true);
        }
        if(health < 0)
        {
            health = 0;
            Destroy(gameObject);
        }
        Debug.Log("enemy health ====================== " + health);

    }

    void enemy_damage()
    {


        if (health > 0)
        {
            //health = get_health();
            health -= 34;
            knockback();
            //animator.SetBool("stab", true);
        }
        if (health < 0)
        {
            health = 0;
            Destroy(gameObject);
        }
        Debug.Log("enemy health ====================== " + health);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            melee = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            melee = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            melee = false;
        }
    }

    public void knockback()
    {
        var dir = center.position - player.transform.position;
       // var dir = center.position - player_pos.transform.position;
        rb.velocity = (Vector2)dir.normalized * knockbackvl;
        StartCoroutine(Unknockback());
        //animator.SetBool("stab", false);
    }

    private IEnumerator Unknockback()
    {
        yield return new WaitForSeconds(knockbacktime);
    }

    /*
     * override protected int get_health()
    {

        return this.health;
    }

    override protected void set_health()
    {
        this.health -= 34;
    }
     * */

}
