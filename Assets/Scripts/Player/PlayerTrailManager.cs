using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrailManager : MonoBehaviour
{
    [SerializeField] TrailRenderer trailRenderer;
    [SerializeField] PlayerController playerController;

    private void Start()
    {
        trailRenderer = transform.GetComponent<TrailRenderer>();
        playerController = transform.parent.GetComponent<PlayerController>();
    }
    private void Update()
    {
        if (playerController.isGrounded)
        {
            trailRenderer.emitting = true;
        }
        else
        {
            trailRenderer.emitting = false;
        }
    }
}
