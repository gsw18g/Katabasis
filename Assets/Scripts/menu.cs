using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public string first_level;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void start_first()
    {
        SceneManager.LoadScene(first_level);
    }

    public void quit()
    {
        Application.Quit();
        Debug.Log("quiting game");
    }
}
