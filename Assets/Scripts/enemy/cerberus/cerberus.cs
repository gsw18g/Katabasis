using UnityEngine;

public class cerberus : MonoBehaviour
{
    bool stop = false;
    float timer = 0f;
    public GameObject player;
    

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

    //public static int health = 100;

    Rigidbody2D rb;
    float dash_speed = 20.0f;//15//10f

    float pos_y;

    public static bool flip = false;

    int last_dir;

    private void Awake()
    {
        initScale = enemy.localScale;

        rb = GetComponent<Rigidbody2D>();
        pos_y = transform.position.y;
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
        if (!stop)
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

        Debug.Log("dir = " + last_dir);

        


        timer += Time.deltaTime;

        //only update last player pos while hades is not attacking
        if (timer < 3f)
        {
            //get last player position
            last_player_pos = player.transform.position;
            last_player_pos.y = pos_y;
        }
        else if (timer > 3f && timer < 3.4f)
        {
            stop = true;

            
            //enemy.position = new Vector3(last_player_pos.x, transform.position.y, 0f);


            animator.SetBool("attack", true);

            if (last_dir == 1 && enemy.transform.position.x - player.transform.position.x > 0)
            {
                flip = true;
            }
            else if (last_dir == -1 && enemy.transform.position.x - player.transform.position.x < 0)
            {
                flip = true;
            }


            var step = dash_speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, last_player_pos, step);
            //apply move toward player to rigidbody
            //rb.transform.position = transform.position;

            
            //rb.transform.position = new Vector3(gameObject.transform.position.x - Time.deltaTime * speed, pos_y, 0f);

        }
        else if (timer > 3.4f && timer < 3.9f)
        {
            //destroy = true;
        }
        else if (timer > 3.9f)
        {
            //destroy = false;
            timer = 0f;
            stop = false;
            flip = false;

            //movingLeft = !movingLeft;

            //animator.SetBool("stab", false);

            animator.SetBool("attack", false);

        }

    }//end update

    private void MoveInDirection(int direction)
    {
        last_dir = direction;
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
