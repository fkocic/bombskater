using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().Die();
            AudioManager.Instance.PlaySplash();
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyHealth>().Die();
            AudioManager.Instance.PlaySplash();
        }

        if (other.gameObject.CompareTag("Enemy Tank"))
        {
            other.gameObject.GetComponent<EnemyHealth>().Die();
            AudioManager.Instance.PlaySplash();
        }
    }
}
