using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header ("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;

    private void Awake()
    {
        initScale = enemy.localScale;
    }

    private void Update()
    {
        MoveInDirection(1);
    }

    private void MoveInDirection(int direction)
    {
        //Make enemy face direciton
        enemy.localScale = new Vector3(Mathfs.Abs(initScale.x * direction), initScale.y, initScale.z);
        //Move in that direction
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * direction * speed,
            enemy.position.y, enemy.position.z);
    }
}
