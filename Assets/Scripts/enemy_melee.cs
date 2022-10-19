using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_melee : MonoBehaviour
{
    player_movement player_pos;
    public GameObject player;

    sword_check sword_range;
    public GameObject the_sword;

    float speed = 1f;
    Rigidbody2D rb;
    //float pos_y = 0f;
    bool sword_hit;
    public static bool melee = false;
    public int health = 100;
    //public static int health;

    public Animator animator;

    [SerializeField] private Transform center;
    [SerializeField] private float knockbackvl=10f;
    [SerializeField] private float knockbacktime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();

        the_sword = GameObject.FindGameObjectWithTag("sword_check");
        sword_range = the_sword.GetComponent<sword_check>();



        //sword_hit = sword_check.hit_melee_enemy;

        //health = 100;
    }

    // Update is called once per frame
    void Update()
    {

        // Move our position a step closer to the target.
        var step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
        rb.transform.position = transform.position;

        ///sword_hit = sword_check.hit_melee_enemy;

        //sword_hit = sword_range.hit_melee_enemy;

        
        sword_hit = sword_range.hit_melee_enemy;

        if (Input.GetMouseButtonDown(0) && sword_hit)//sword_hit
        {
            animator.SetBool("start_death", true);
            // Destroy(gameObject);
            //enemy_damage();
            
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
           
        }
        if (health < 0)
        {
            health = 0;
            
            //animator.SetBool("start_death", true);
            //Destroy(gameObject);
        }
        Debug.Log("enemy health ====================== " + health);

    }

    public void end_death_anim()
    {
        Destroy(gameObject);
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
        rb.velocity = (Vector2)dir.normalized * knockbackvl;
        StartCoroutine(Unknockback());
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
