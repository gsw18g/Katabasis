using UnityEngine;

public class zombie_patrol : MonoBehaviour
{
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
    [SerializeField] private Animator anim;

    [Header("Idle Behavior")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    public GameObject the_zombie;
    enemy_melee zombie;
    bool awake = false;
    int last_dir = 1;

    private void Start()
    {
        zombie = enemy.GetComponent<enemy_melee>();
    }

    private void Awake()
    {
        initScale = enemy.localScale;
    }

    private void DirectionChange()
    {
        //anim.SetBool("moving", false);
        idleTimer += Time.deltaTime;

        if (idleTimer > idleDuration)
            movingLeft = !movingLeft;
    }

    private void Update()
    {
        awake = zombie.awake;

        if(!awake)
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
        else
        {
            Debug.Log("awake is true");
            //flip zombie so he faces player before enemy_melee takes over movement
            if(last_dir == -1)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            
        }

        
    }

    private void MoveInDirection(int direction)
    {
        last_dir = direction;
        idleTimer = 0;
        //anim.SetBool("moving", true);
        //Make enemy face direciton
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * -direction, initScale.y, initScale.z);
        //Move in that direction
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * direction * speed,
            enemy.position.y, enemy.position.z);
    }
}
