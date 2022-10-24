using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behaviour : MonoBehaviour
{
	public Transform player;
	public float moveSpeed = 5f;
	private Vector2 movement;
	private Rigidbody2D rb;
	public static bool bat_melee;

    //public GameObject bat;
    //sword_check in_range;

    private bool hit_bat = false;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       movement=player.position-transform.position;
	   movement.Normalize();

        //in_range = bat.GetComponent<sword_check>();

        if(hit_bat && Input.GetMouseButtonDown(0))
        {
            Destroy(gameObject);
        }
    }

	private void FixedUpdate(){
		moveCharacter(movement);
	
	}

	void moveCharacter(Vector2 dir){
		rb.MovePosition((Vector2)transform.position+(dir*moveSpeed*Time.deltaTime));
	
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            bat_melee = true;
        }

        if (collision.transform.CompareTag("sword_check"))
        {
            hit_bat = true;
        }

        /*
         *  if(in_range.hit_melee_enemy && Input.GetMouseButtonDown(0))
         {
             Destroy(gameObject);
         }
         * */
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            bat_melee = true;
        }

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
