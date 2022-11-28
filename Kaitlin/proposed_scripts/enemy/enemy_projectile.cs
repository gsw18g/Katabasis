// enemy_projectile.cs: Activates, moves, and deactivates arrow when it hits an object
// written by: Gavin Williams
// reviewed by: Kaitlin Tran

using UnityEngine;

public class enemy_projectile : EnemyDamage
{
    [SerializeField] private float speed;
    [SerializeField] private float reset_time;
    private float lifetime;
    private Animator anim;
    private BoxCollider2D box_collider;

    private bool hit;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        box_collider = GetComponent<BoxCollider2D>();
    }

    public void ActivateProjectile()
    {
        hit = false;
        lifetime = 0;
        gameObject.SetActive(true);
        box_collider.enabled = true;
    }
    
    private void Update()
    {
        if (hit) return;
        float movement_speed = speed * Time.deltaTime;
        transform.Translate(movement_speed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > reset_time)
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        box_collider.enabled = false;
        Debug.Log(collision.tag);
        
        if (collision.transform.CompareTag("Player"))
        {
            collision.GetComponent<player_health>().player_damage();
        }
        else if (collision.transform.CompareTag("sword_check"))
        {
            GameObject obj = collision.gameObject;
            GameObject parent_obj = obj.transform.parent.gameObject;
            parent_obj.GetComponent<player_health>().player_damage();
        }

        gameObject.SetActive(false); // When this hits any object deactivate arrow
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
