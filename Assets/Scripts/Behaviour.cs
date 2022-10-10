using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behaviour : MonoBehaviour
{
	public Transform player;
	public float moveSpeed = 5f;
	private Vector2 movement;
	private Rigidbody2D rb;
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
    }

	private void FixedUpdate(){
		moveCharacter(movement);
	
	}

	void moveCharacter(Vector2 dir){
		rb.MovePosition((Vector2)transform.position+(dir*moveSpeed*Time.deltaTime));
	
	}







}
