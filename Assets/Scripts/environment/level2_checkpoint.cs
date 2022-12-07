using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level2_checkpoint : MonoBehaviour
{
    public static bool checkpoint = false;

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
        checkpoint = true;
        //SceneManager.LoadScene(4);
        Debug.Log("checkpoint reached");
    }
}
