// hades.cs: Moves hades like a normal enemy to follow player
// written by: Matthew Kaplan
// reviewed by: Kaitlin Tran
// TODO: implement OnTriggerEnter2D(), OnTriggerStay2D(), OnTriggerExit2D()

using UnityEngine;

public class hades : MonoBehaviour
{
    bool stop = false;
    float timer = 0f;
    public GameObject player;
    public static bool destroy = false;

    Vector3 last_player_pos;

    [Header("Patrol Points")]
    [SerializeField] private Transform left_edge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement parameters")]
    [SerializeField] private float speed;
    private Vector3 init_scale;
    private bool moving_left;

    [Header("Enemy Animator")]

    [Header("Idle Behavior")]
    [SerializeField] private float idle_duration;
    private float idle_timer;

    private void Awake()
    {
        initScale = enemy.localScale;
    }

    private void DirectionChange()
    {
        idle_timer += Time.deltaTime;

        if (idleTimer > idleDuration && !stop)
            moving_left = !moving_left;
    }

    private void Update()
    {
        if (movingLeft)
        {
            if (enemy.position.x >= left_edge.position.x)
                MoveInDirection(-1);
            else
            {
                DirectionChange();
            }
        }
        else
        {
            if (enemy.position.x <= right_edge.position.x)
                MoveInDirection(1);
            else
            {
                DirectionChange();
            }
        }

        timer += Time.deltaTime;

        //only update last player pos while hades is not attacking
        if (timer < 3f)
        {
            //get last player position
            last_player_pos = player.transform.position;
        }
        else if (timer > 3f && timer < 4f)
        {
            stop = true;
            enemy.position = new Vector3(last_player_pos.x, transform.position.y, 0f);
            
            if (enemy.position.x % 1.5f != 0)
            {
                enemy.transform.position = new Vector3(enemy.transform.position.x - (enemy.transform.position.x % 1.5f), transform.position.y, 0f);
            }

            destroy = true;

        }
        else if (timer > 4f)
        {
            timer = 0f;
            stop = false;
            destroy = false;
            movingLeft = !movingLeft;
        }
    }

    private void MoveInDirection(int direction)
    {
        idleTimer = 0;
        //Make enemy face direciton
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * direction, initScale.y, initScale.z);
        //Move in that direction
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * direction * speed,
            enemy.position.y, enemy.position.z);
    }
}
