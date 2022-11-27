// enemy_patrol.cs: Idle enemy patrolling movement
// written by: Gavin Williams

using UnityEngine;

public class enemy_patrol : MonoBehaviour
{
    [Header ("Patrol Points")]
    [SerializeField] private Transform left_edge;
    [SerializeField] private Transform right_edge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement parameters")]
    [SerializeField] private float speed;
    private Vector3 init_scale;
    private bool moving_left;

    [Header("Enemy Animator")]
    [SerializeField] private Animator anim;

    [Header("Idle Behavior")]
    [SerializeField] private float idle_duration;
    private float idle_timer;

    private void Awake()
    {
        init_scale = enemy.localScale;
    }

    private void DirectionChange()
    {
        anim.SetBool("moving", false);
        idle_timer += Time.deltaTime;

        if(idle_timer > idle_duration)
            moving_left = !moving_left;
    }

    private void Update()
    {
        if (moving_left)
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
    }

    private void MoveInDirection(int direction)
    {
        idle_timer = 0;
        anim.SetBool("moving", true);
        // Make enemy face direciton
        enemy.localScale = new Vector3(Mathf.Abs(init_scale.x) * direction, init_scale.y, initScale.z);
        // Move in that direction
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * direction * speed,
            enemy.position.y, enemy.position.z);
    }
}
