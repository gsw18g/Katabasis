using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword_check : MonoBehaviour
{
    public static bool hit_melee_enemy;

    // Start is called before the first frame update
    void Start()
    {
        hit_melee_enemy = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("enemy_melee"))
        {
            hit_melee_enemy = true;
            //Debug.Log("inside sword cirlce");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("enemy_melee"))
        {
            hit_melee_enemy = true;
            //Debug.Log("inside sword cirlce");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("enemy_melee"))
        {
            hit_melee_enemy = false;
            //Debug.Log("outside sword cirlce");
        }
    }

}

