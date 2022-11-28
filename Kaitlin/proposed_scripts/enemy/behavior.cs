// behavior.cs: Bat enemy behavior to follow and “hit” player and check if bat has been hit by player
// written by: Matthew Kaplan
// reviewed by: Kaitlin Tran
// TODO: is this one being used anymore?

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class behavior : MonoBehaviour
{
    public Transform player;
    public float move_speed = 5f;
    private Vector2 movement;
    private Rigidbody2D rb;
    // bool to check if player should be knocked back and damaged
    public static bool bat_melee;
    private bool hit_bat = false;
    // adds offset so the bat isnt right on top of the player
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        offset = new Vector3(1f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        // adds offset in the x direction to put a little space between the bat and player
        movement = player.position - transform.position + offset;
	movement.Normalize();

        if(hit_bat && Input.GetMouseButtonDown(0))
        {
            Destroy(gameObject);
        }
    }
    
    private void FixedUpdate()
    {
	moveCharacter(movement);
    }

    void moveCharacter(Vector2 dir)
    {
	rb.MovePosition((Vector2)transform.position + (dir * move_speed * Time.deltaTime));
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check if should do player knockback and damage
    
    	if (collision.transform.CompareTag("Player"))
        {
            bat_melee = true;
        }

        //check if bat is in range of player sword
        if (collision.transform.CompareTag("sword_check"))
        {
            hit_bat = true;
        }      
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //check if should do player knockback and damage
        if (collision.transform.CompareTag("Player"))
        {
            bat_melee = true;
        }

        //check if bat is in range of player sword
        if (collision.transform.CompareTag("sword_check"))
        {
            hit_bat = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            bat_melee = false;
        }

        if (collision.transform.CompareTag("sword_check"))
        {
            hit_bat = false;
        }
    }
}
