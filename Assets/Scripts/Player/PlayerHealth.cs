using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 startingCoordinates;
    private PlayerController controller;
    private MeshRenderer meshRenderer;
    private int currentHealth = 3;
    private Color originalColor;

    [SerializeField] ParticleSystem explosion;
    [SerializeField] int maxHealth = 3;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] GameObject playerModel;

    void Start()
    {
        startingCoordinates = transform.position;
        controller = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody>();
        //modelMesh = GetComponent<MeshRenderer>();
        currentHealth = maxHealth;
        //originalColor = meshRenderer.material.color;
    }

    private void UpdateHealthText()
    {
        healthText.text = $"Health: {currentHealth.ToString()}";
    }

    public void TakeDamage()
    {
        currentHealth--;
        if (currentHealth <= 0) Die();
        UpdateHealthText();
        AudioManager.Instance.PlayExplosion();
        //StartCoroutine(FlashRed());
    } 

    public void Die()
    {
        AudioManager.Instance.PlayGameOver();
        ScoreManager.Instance.CheckScores();
        StartCoroutine(DelayedDeath());
    }

    public void PlayExplosion()
    {
        explosion.Play();
    }

    IEnumerator FlashRed()
    {
        meshRenderer.material.color = new Color(1, 0, 0);
        yield return new WaitForSeconds(0.5f);
        meshRenderer.material.color = originalColor;
    }

    IEnumerator DelayedDeath()
    {
        controller.isDying = true;
        rb.useGravity = false;
        playerModel.SetActive(false);
        //meshRenderer.enabled = false;
        PlayExplosion();

        yield return new WaitForSeconds(1);

        LevelManager.Instance.GameOver();
        /*
        transform.position = startingCoordinates;
        transform.rotation = Quaternion.identity;
        //meshRenderer.enabled = true;
        rb.useGravity = true;
        controller.isDying = false;
        */
    }
}
