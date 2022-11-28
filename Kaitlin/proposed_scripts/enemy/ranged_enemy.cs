// ranged_enemy.cs: Ranged enemy behavior when it sees player and takes damage
// written by: Gavin Williams, Matthew Kaplan
// reviewed by: Kaitlin Tran

using UnityEngine;

public class ranged_enemy : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private float attack_cooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;

    [Header("Ranged Attack")]
    [SerializeField] private Transform projectile_point;
    [SerializeField] private GameObject[] projectile;

    [Header("Collider Parameters")]
    [SerializeField] private float collider_distance;
    [SerializeField] private BoxCollider2D box_collider;

    [Header("Player Layer")]
    [SerializeField] private LayerMask player_layer;
    private float cooldown_timer = Mathf.Infinity;

    private Animator anim;
    private EnemyPatrol enemy_patrol;

    bool take_damage;
    public int health = 100;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        cooldown_timer += Time.deltaTime;

        if (PlayerInSight())
        {
            if(cooldown_timer >= attack_cooldown)
            {
                cooldown_timer = 0;
                anim.SetTrigger("RangedAttack");
            }
        }

        // if hit left mouse button and enemy is inside sword stab range(take_damage == true)
        if (Input.GetMouseButtonDown(0) && take_damage)
        {
            enemy_damage();
        }
    }

    private void RangedAttack()
    {
        cooldown_timer = 0;
        projectile[FindProjectile()].transform.position = projectile_point.position;
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
            Physics2D.BoxCast(box_collider.bounds.center + transform.right * range * transform.localScale.x * collider_distance,
            new Vector3(box_collider.bounds.size.x * range, box_collider.bounds.size.y, box_collider.bounds.size.z),
            0, Vector2.left, 0, player_layer);

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(box_collider.bounds.center + transform.right * range * transform.localScale.x * collider_distance,
            new Vector3(box_collider.bounds.size.x * range, box_collider.bounds.size.y, box_collider.bounds.size.z));
    }

    void enemy_damage()
    {
        // if health is positive substract 34 and knockback enemy
        if (health > 0)
        {
            health -= 34;
            // knockback();
        }
        
        // if enemy has 0 health play death animation
        if (health < 0)
        {
            health = 0;
            // destroy enemy
            Destroy(gameObject);            
        }
    }

    // when enemy trigger collider 1st collides with player sword set take damage to true 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("sword_check"))
        {
            take_damage = true;
        }
    }

    // when enemy trigger collider continues to collide with player sword set take damage to true 
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("sword_check"))
        {
            take_damage = true;
        }
    }

    // when enemy trigger collider stops colliding with player sword set take damage to false
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("sword_check"))
        {
            take_damage = false;
        }
    }
}
