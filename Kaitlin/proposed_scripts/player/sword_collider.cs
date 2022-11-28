// sword_collider.cs: Checks if sword hits enemy
// written by: Matthew Kaplan
// reviewed by: Kaitlin Tran

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword_collider : MonoBehaviour
{
    public static bool sword_collider_hit;
    // Start is called before the first frame update
    void Start()
    {
        sword_collider_hit = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("enemy_melee"))
        {
            sword_collider_hit = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("enemy_melee"))
        {
            sword_collider_hit = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("enemy_melee"))
        {
            sword_collider_hit = false;
        }
    }
}
