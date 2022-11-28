// melee_enemy.cs: gets and sets health of enemy when damaged
// written by: Gavin Williams, Matthew Kaplan
// reviewed by: Kaitlin Tran

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class melee_enemy : MonoBehaviour
{


    public int health = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected int get_health()
    {

        return health;
    }

    protected void set_health()
    {
        health -= 34;
    }

}
