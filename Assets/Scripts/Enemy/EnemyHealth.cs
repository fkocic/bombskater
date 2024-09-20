using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public void Die()
    {
        Destroy(gameObject);
        ScoreManager.Instance.IncreaseScore(1);
    }

    public void TankDie()
    {
        GetComponentInChildren<DestructionSphereBehaviour>().DestroyTiles();
        ScoreManager.Instance.IncreaseScore(1);
    }
}
