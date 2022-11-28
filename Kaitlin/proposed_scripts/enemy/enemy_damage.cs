// enemy_damage.cs: Give player “damage”
// written by: Gavin Williams
// reviewed by: Kaitlin Tran

using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            collision.GetComponent<player_health>().player_damage();
    }

    protected void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            collision.GetComponent<player_health>().player_damage();
    }
}
