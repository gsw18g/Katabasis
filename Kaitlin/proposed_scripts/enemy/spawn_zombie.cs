// spawn_zombie.cs: Instantiate zombie object when scene starts
// written by: Matthew Kaplan

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_zombie : MonoBehaviour
{
    public GameObject enemy;
    Vector3 pos;

    int size = 2;

    GameObject[] zombies = new GameObject[2];//20,10,10

    // Start is called before the first frame update
    void Start()
    {
        pos = new Vector3(5f, -3.91f, 0f);

        for(int i = 0; i < 2; i++)
        {
            zombies[i] = Instantiate(enemy, new Vector3(i * pos.x,pos.y,0f), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
