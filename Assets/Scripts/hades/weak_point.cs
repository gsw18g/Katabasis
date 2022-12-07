using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weak_point : MonoBehaviour
{
    public static int health = 300;

    bool take_damage = false;
    private UIManager UIManager;
    public static bool win_game = false;
    public GameObject hades;
    // Start is called before the first frame update
    void Start()
    {
        UIManager = FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && take_damage)
        {
            damage();
        }
    }

    void damage()
    {
        

        health -= 10;

        if(health < 0)
        {
            health = 0;
            UIManager.WinGame();
            win_game = true;
            Destroy(hades);
           
        }

        Debug.Log("hades health = " + health);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("sword_check"))
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
