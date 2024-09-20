using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    public static AudioManager Instance { get; private set; }
    /*
    [SerializeField] AudioSource bounce;
    [SerializeField] AudioSource boom;
    [SerializeField] AudioSource woosh;
    [SerializeField] AudioSource bgMusic;
    [SerializeField] AudioSource trashClang;
    */

    [SerializeField] AudioSource ambiance;
    [SerializeField] AudioSource menuTheme;
    [SerializeField] AudioSource arenaMusic;
    [SerializeField] AudioSource bombPlant;
    [SerializeField] AudioSource countdown;
    [SerializeField] AudioSource explosion;
    [SerializeField] AudioSource splash;
    [SerializeField] AudioSource gameOver;
    [SerializeField] AudioSource jump;
    [SerializeField] AudioSource pop;
    [SerializeField] AudioSource skating;



    void Awake()
    {
        /*
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
            return;
        }
        Destroy(this.gameObject);
        */

        Instance = this;
    }

    public void PlayMainMenuTheme()
    {
        menuTheme.Play();
    }

    public void PlayArenaMusic()
    {
        arenaMusic.Play();
    }

    public void PlayBombPlant()
    {
        bombPlant.Play();
    }

    public void PlayCountdown()
    {
        countdown.Play();
    }

    public void PlayExplosion()
    {
        explosion.Play();
    }

    public void PlaySplash()
    {
        splash.Play();
    }

    public void PlayGameOver()
    {
        gameOver.Play();
    }

    public void PlayJump()
    {
        jump.Play();
    }

    public void PlayPop()
    {
        pop.Play();
    }

    public void PlaySkating()
    {
        skating.Play();
    }

    public void StopSkating()
    {
        skating.Stop();
    }

    public void PlayAmbiance()
    {
        ambiance.Play();
    }

    public void StopAmbiance()
    {
        ambiance.Stop();
    }
}
