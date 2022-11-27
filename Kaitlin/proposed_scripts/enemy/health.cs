
// health.cs: health system animations for player?
// written by: Gavin Williams
// TODO: move to player folder if this is for the player

using UnityEngine;
using System.Collections;

public class health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float starting_health;
    public float current_health { get; private set; }
    private Animator anim;
    private bool dead;

    [Header("iFrames")]
    [SerializeField] private float iframes_duration;
    [SerializeField] private int number_of_flashes;
    private SpriteRenderer sprite_rend;

    [Header("Components")]
    [SerializeField] private behavior[] components;
    private bool invulnerable;

    private void Awake()
    {
        currentHealth = starting_health;
        anim = GetComponent<Animator>();
        sprite_rend = GetComponent<SpriteRenderer>();
    }
    public void TakeDamage(float _damage)
    {
        if (invulnerable) return;
        current_health = Mathf.Clamp(current_health - _damage, 0, starting_health);

        if (current_health > 0)
        {
            anim.SetTrigger("hurt");
            StartCoroutine(Invunerability());
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("die");

                //Deactivate all attached component classes
                foreach (Behaviour component in components)
                    component.enabled = false;

                dead = true;
            }
        }
    }
    
    public void AddHealth(float _value)
    {
        current_health = Mathf.Clamp(current_health + _value, 0, starting_health);
    }
    
    private IEnumerator Invunerability()
    {
        invulnerable = true;
        Physics2D.IgnoreLayerCollision(10, 11, true);
        
        for (int i = 0; i < number_of_flashes; i++)
        {
            sprite_rend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iframes_duration / (number_of_flashes * 2));
            sprite_rend.color = Color.white;
            yield return new WaitForSeconds(iframes_duration / (number_of_flashes * 2));
        }
        
        Physics2D.IgnoreLayerCollision(10, 11, false);
        invulnerable = false;
    }
}
