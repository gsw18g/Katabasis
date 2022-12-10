using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cerberus_weak_point : MonoBehaviour
{
    public static int health = 200;

    bool take_damage = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && take_damage)
        {
            damage();
        }
    }

    void damage()
    {


        health -= 10;

        //if cereberus is dead
        if (health < 0)
        {
            health = 0;
            Destroy(gameObject);
            //load hades scene
            SceneManager.LoadScene(6);
            //reset checkpoint
            level2_checkpoint.checkpoint = false;
        }

        Debug.Log("cerberus health = " + health);
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
