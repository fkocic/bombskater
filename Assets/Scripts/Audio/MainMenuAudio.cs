using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAudio : MonoBehaviour
{
    private void Start()
    {
        AudioManager.Instance.PlayMainMenuTheme();
    }
}
