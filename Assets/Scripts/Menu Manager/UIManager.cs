using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    //[SerializeField] private AudioClip gameOverSound;

    Scene current_scene;
    string scene_name;

    private void Awake()
    {
        gameOverScreen.SetActive(false);

        //get current active scene name
        current_scene = SceneManager.GetActiveScene();
        scene_name = current_scene.name;
    }

    #region Game Over Functions
    //Game over function
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        //SoundManager.instance.PlaySound(gameOverSound);
    }

    //Restart level
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        //if scene == hades reset hades health on restart
        if(scene_name == "hades")
        {
            weak_point.health = 300;
        }
        else if(scene_name == "level 2 test")
        {
            cerberus_weak_point.health = 200;
        }
    }

    //Activate game over screen
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    //Quit game/exit play mode if in Editor
    public void Quit()
    {
        //Application.Quit(); //Quits the game (only works in build)

        UnityEditor.EditorApplication.isPlaying = false; //Exits play mode
    }
    #endregion
}