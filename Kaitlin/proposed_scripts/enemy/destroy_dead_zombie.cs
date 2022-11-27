// destroy_dead_zombie.cs: Destroys zombie object when it’s dead
// written by: Matthew Kaplan
// TODO: possibly organize into somewhere else?

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_dead_zombie : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void end_death_anim()
    {
        Destroy(gameObject);
        
    }
}
