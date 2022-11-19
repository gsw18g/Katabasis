using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;

    [Header("Ranged Attack")]
    [SerializeField] private Transform projectilePoint;
    [SerializeField] private GameObject[] projectile;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    private Animator anim;
    private EnemyPatrol enemyPatrol;

    bool take_damage;
    public int health = 100;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (PlayerInSight())
        {
            if(cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("RangedAttack");
            }
        }

        //if hit left mouse button and enemy is inside sword stab range(take damage == true)
        if (Input.GetMouseButtonDown(0) && take_damage)
        {
            enemy_damage();
        }
    }

    private void RangedAttack()
    {
        cooldownTimer = 0;
        projectile[FindProjectile()].transform.position = projectilePoint.position;
        projectile[FindProjectile()].GetComponent<EnemyProjectile>().ActivateProjectile();
    }

    private int FindProjectile()
    {
        for (int i = 0; i < projectile.Length; i++)
        {
            if (!projectile[i].activeInHierarchy)
                return i;
        }
        return 0;
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit =
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    void enemy_damage()
    {
        //if health is positive substract 34 and knockback enemy
        if (health > 0)
        {
            health -= 34;
            //knockback();
        }
        //if enemy has 0 health play death animation
        if (health < 0)
        {
            health = 0;

            //destroy enemy
            Destroy(gameObject);
            
            //animator.SetBool("start_death", true);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.transform.CompareTag("sword_check"))
        {
            take_damage = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        

        if (collision.transform.CompareTag("sword_check"))
        {
            take_damage = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        

        if (collision.transform.CompareTag("sword_check"))
        {
            take_damage = false;
        }
    }

}
