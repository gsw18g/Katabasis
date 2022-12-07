using UnityEngine;

public class hades : MonoBehaviour
{
    bool stop = false;
    float timer = 0f;
    public GameObject player;
    public static bool destroy = false;

    public Animator animator;

    Vector3 last_player_pos;

    [Header("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    [Header("Enemy Animator")]
    //[SerializeField] private Animator anim;

    [Header("Idle Behavior")]
    [SerializeField] private float idleDuration;
    private float idleTimer;


    float fireball_timer = 0f;
    //public int health = 100;

    private void Awake()
    {
        initScale = enemy.localScale;
    }

    private void DirectionChange()
    {
        //anim.SetBool("moving", false);
        idleTimer += Time.deltaTime;

        if (idleTimer > idleDuration && !stop)
            movingLeft = !movingLeft;
    }

    private void Update()
    {
        //if hades is not stopped move back and forth between the left and right edges
        if(!stop)
        {
            if (movingLeft)
            {
                if (enemy.position.x >= leftEdge.position.x)
                    MoveInDirection(-1);
                else
                {
                    DirectionChange();
                }
            }
            else
            {
                if (enemy.position.x <= rightEdge.position.x)
                    MoveInDirection(1);
                else
                {
                    DirectionChange();
                }
            }
        }
        

        timer += Time.deltaTime;
        

        //only update last player pos while hades is not attacking
        if (timer < 3f)
        {
            //get last player position
            last_player_pos = player.transform.position;
        }
        else if (timer > 3f && timer < 3.1f)
        {
            stop = true;

            //enemy.position = new Vector3(player.transform.position.x, transform.position.y, 0f);
            enemy.position = new Vector3(last_player_pos.x, transform.position.y, 0f);
            if (enemy.position.x % 1.5f != 0)//enemy.position.x % 1.5f != 0
            {
                enemy.transform.position = new Vector3(enemy.transform.position.x - (enemy.transform.position.x % 1.5f), transform.position.y, 0f);
            }

            animator.SetBool("stab", true);

            

        }
        else if(timer > 3.4f && timer < 3.9f)
        {
            destroy = true;
        }
        else if (timer > 3.9f)
        {
            destroy = false;
            timer = 0f;
            stop = false;
            
            movingLeft = !movingLeft;

            //animator.SetBool("stab", false);

            //animator.SetBool("idle", true);

        }

        if(animator.GetBool("stab") == false)
        {
            if(fireball.shoot)
            {
                animator.SetBool("fire", true);
            }

            /*
             * fireball_timer += Time.deltaTime;

            if(fireball_timer > 1f)
            {
                animator.SetBool("sweep", true);
                fireball_timer = 0f;
            }
             * */

            
        }
        /*
         * else
        {
            fireball_timer = 0f;
        }
         * */


    }//end update

    private void MoveInDirection(int direction)
    {
        idleTimer = 0;
        //anim.SetBool("moving", true);
        //Make enemy face direciton
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * direction, initScale.y, initScale.z);
        //Move in that direction
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * direction * speed,
            enemy.position.y, enemy.position.z);
    }

    public void reset_stab()
    {
        
        animator.SetBool("stab", false);
        
    }

    public void reset_sweep()
    {
        animator.SetBool("fire", false);
        fireball.shoot = false;
        
    }

    /*
     *    private void OnTriggerEnter2D(Collider2D collision)
       {
           Debug.Log("on trigger enter");
           if(collision.transform.CompareTag("hades_block"))
           {
               Destroy(collision.gameObject);
           }
       }

       private void OnTriggerStay2D(Collider2D collision)
       {

       }

       private void OnTriggerExit2D(Collider2D collision)
       {

       }
     * */
}
