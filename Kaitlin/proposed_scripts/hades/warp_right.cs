// warp_right.cs: Warps position of player? Same as warp.cs except Vector3 value is different
// written by: Matthew Kaplan
// TODO: empty if statements

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warp_right : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            player.transform.position = new Vector3(8.58f, 13.75f, 0);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {

        }
    }
}
