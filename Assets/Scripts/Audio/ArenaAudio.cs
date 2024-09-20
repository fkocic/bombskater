using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaAudio : MonoBehaviour
{
    private void Start()
    {
        AudioManager.Instance.PlayArenaMusic();
    }
}
