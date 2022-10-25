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

    //protected abstract int get_health();
    //protected abstract void set_health();

    protected int get_health()
    {

        return health;
    }

    protected void set_health()
    {
        health -= 34;
    }

}
