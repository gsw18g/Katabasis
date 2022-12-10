using UnityEngine.Audio;
using UnityEngine;

public class SFXManager : MonoBehaviour
{

    public AudioSource Audio;

    public AudioClip playerHurt;
    public AudioClip playerStab;
    public AudioClip playerJump;
    public AudioClip playerDeath;
    public AudioClip zombieAttack;
    public AudioClip zombieDeath;
    public AudioClip batAttack;
    public AudioClip batDeath;

    public static SFXManager sfxInstance;

    private void Awake() 
    {
        if (sfxInstance is null && sfxInstance != this) 
        {
            Destroy(this.gameObject);
            return;
        }
        sfxInstance = this;
        DontDestroyOnLoad(this);
    }
}
