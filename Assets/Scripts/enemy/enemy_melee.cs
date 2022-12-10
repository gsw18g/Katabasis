using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_melee : MonoBehaviour
{
    private GameObject player;
    public float speed = 2f;
    Rigidbody2D rb;
    //check if player has been meleed by enemy
    public static bool melee = false;
    public int health = 100;
    public Animator animator;
    //check if enemy should take damage
    private bool take_damage;
    public bool awake = false;

    public GameObject zombie_death;

    public bool stop_awake = false;

    [SerializeField] private Transform center;
    [SerializeField] private float knockbackvl=10f;
    [SerializeField] private float knockbacktime = 1f;

    

    // Start is called before the first frame update
    void Start()
    {
        //assign player
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
 
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if(awake)
        {
            SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.zombieAttack); // audio glitch HERE
            // Move our position a step closer to the target.
            var step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
            //apply move toward player to rigidbody
            rb.transform.position = transform.position;
        }
        

        //if left mouse pressed and take_damage == true (enemy has been hit with sword)
        if (Input.GetMouseButtonDown(0) && take_damage)
        {
            //apply damage to enemy
            enemy_damage();
            
        }

    }

    void enemy_damage()
    {
        //if health is positive substract 34 and knockback enemy
        if (health > 0)
        {
            health -= 34;
            knockback(); 
        }
        //if enemy has 0 health play death animation
        if (health < 0)
        {
            SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.zombieDeath);
            health = 0;
            //animator.SetBool("start_death", true);

            //spawn zombie death animation where zombie died
            Instantiate(zombie_death, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.identity);
            Destroy(gameObject);
        }

    }

    //at end of death animation destroy enemy gameobject
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

        if(collision.transform.CompareTag("sword_check"))
        {
            take_damage = true;
        }

        if(collision.transform.CompareTag("zombie_awake") && !stop_awake)
        {
            awake = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {


            melee = true;
        }

        if (collision.transform.CompareTag("sword_check"))
        {
            take_damage = true;
        }

        if (collision.transform.CompareTag("zombie_awake") && !stop_awake)
        {
            awake = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {


            melee = false;
        }

        if (collision.transform.CompareTag("sword_check"))
        {
            take_damage = false;
        }

        if (collision.transform.CompareTag("zombie_awake") && !stop_awake)
        {
            awake = false;
        }
    }

    //knock enemy back
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

   

}
