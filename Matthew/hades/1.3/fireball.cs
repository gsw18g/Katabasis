using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
    float mag = 10f;
    Rigidbody2D rb;
    Vector2 fireball_force;
    float timer = 0f;
    public GameObject the_fireball;
    public GameObject player;

    public float distance = 0f;
    float speed = 2f;


    // Start is called before the first frame update
    void Start()
    {
        fireball_force = new Vector2(-mag, mag);

        //rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = transform.position.x - player.transform.position.x;
        timer += Time.deltaTime;
        
        if(timer > 1f)
        {
            //instantiate fireball object and add force to rigidbody
            var ball = Instantiate(the_fireball, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.identity);
            //rb = ball.GetComponent<Rigidbody2D>();

            //rb.AddForce(fireball_force, ForceMode2D.Impulse);
            //reset timer
            timer = 0f;


        }
        
    }
}
