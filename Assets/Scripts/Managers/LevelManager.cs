using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public bool isInCountdown;

    [SerializeField] TextMeshProUGUI countdownText;
    [SerializeField] GameObject gameOverPanel;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        AudioManager.Instance.PlayAmbiance();
        isInCountdown = true;
        yield return new WaitForSeconds(1);
        countdownText.text = "3";
        AudioManager.Instance.PlayCountdown();
        yield return new WaitForSeconds(1);
        countdownText.text = "2";
        yield return new WaitForSeconds(1);
        countdownText.text = "1";
        yield return new WaitForSeconds(1);
        countdownText.text = "Go!";
        AudioManager.Instance.StopAmbiance();
        AudioManager.Instance.PlayArenaMusic();
        AudioManager.Instance.PlaySkating();
        isInCountdown = false;
        yield return new WaitForSeconds(1);
        countdownText.text = "";
    }

    public void GameOver()
    {
        GameManager.Instance.PauseGame();
        gameOverPanel.SetActive(true);
    }
}
