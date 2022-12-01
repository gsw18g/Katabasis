using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BATBehaviour : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    private Vector2 movement;
    private Rigidbody2D rb;
    //bool to check if player should be knocked back and damaged
    public static bool bat_melee;
    private bool hit_bat = false;
    //adds offset so the bat isnt right on top of the player
    private Vector3 offset;
    public float radius;//5F
    [Range(1, 360)] public float angle = 360f;
    public LayerMask targetLayer;
    public float pause = 0f;
    public float timepause = 1f;
    public bool CanSeePlayer { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        offset = new Vector3(1f, 0f, 0f);
        StartCoroutine(FOVCHECK());
    }

    // Update is called once per frame
    void Update()
    {
        //adds offset in the x direction to put a little space between the bat and player
        movement = player.position - transform.position + offset;
        movement.Normalize();
        if (hit_bat && Input.GetMouseButtonDown(0))
        {
            Destroy(gameObject);
        }


    }

    private IEnumerator FOVCHECK()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);
        while (true)
        {

            yield return wait;
            FOV();
        }
    }

    private void FOV()
    {
        Collider2D[] rangeCheck = Physics2D.OverlapCircleAll(transform.position, radius, targetLayer);
        if (rangeCheck.Length > 0)
        {

            Transform target = rangeCheck[0].transform;
            Vector2 directionToTarget = (target.position - transform.position).normalized;
            if (Vector2.Angle(transform.up, directionToTarget) < angle / 2)
            {
                CanSeePlayer = true;
            }
            else
                CanSeePlayer = false;

        }
        else if (CanSeePlayer)
            CanSeePlayer = false;


    }

    private void FixedUpdate()
    {

        if (CanSeePlayer)
        {
            Vector2 original = transform.position;
            if(pause>timepause)
            {
                rb.isKinematic = false;
                if(pause>timepause+0.4)
                    MoveAttack();
                else
                    MoveDown();
                pause+=Time.deltaTime;
            }
            else
            {
                rb.isKinematic = true;
                rb.MovePosition((Vector2)original);
                pause += Time.deltaTime;

            }
            
        
        }//Invoke(nameof(MoveAttack), 1f);
        else
            moveCharacter(movement);

    }

    void MoveDown()
    {
        Vector3 d;
        d = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z) - transform.position;
        rb.MovePosition((Vector3)transform.position + (d * moveSpeed * Time.deltaTime));
    }
    void MoveAttack()
    {
        Vector3 dir;

        if (player.position.x>transform.position.x)
        {
            dir = new Vector3(transform.position.x+1, transform.position.y, transform.position.z) - transform.position;
        }
        else
        {
            dir = new Vector3(transform.position.x-1, transform.position.y, transform.position.z) - transform.position;
        }
        rb.MovePosition((Vector3)transform.position + (dir * moveSpeed * Time.deltaTime));

    }
    void moveCharacter(Vector2 dir)
    {
        
        rb.MovePosition((Vector2)transform.position + (dir * moveSpeed * Time.deltaTime));

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("bat"))
        {
            hit_bat = true;
            movement = transform.position + offset - collision.transform.position;
            movement.Normalize();

        }
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
            //hit_bat = true;
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

        if (collision.transform.CompareTag("bat"))
        {

            movement = transform.position + offset - collision.transform.position;
            movement.Normalize();

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

        if (collision.transform.CompareTag("bat"))
        {
            movement = transform.position + offset - collision.transform.position;
            movement.Normalize();

        }

    }







}
