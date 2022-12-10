using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerScene3 : MonoBehaviour
{
    float timer;
    private UIManager UIManager;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        UIManager = FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 90f)
            UIManager.WinScreen();
    }
}