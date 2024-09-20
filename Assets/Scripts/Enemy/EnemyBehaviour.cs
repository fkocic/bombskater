using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Transform forwardVector;
    [SerializeField] float speed = 1.5f;
    [SerializeField] float rotationSpeed = 180;
    [SerializeField] float stopTrackRadius = 2;

    private bool isFollowing = false;

    private void Update()
    {
        if (isFollowing)
        {        
            Vector3 targetDirection = target.position - transform.position;
            targetDirection.y = 0;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, rotationSpeed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }

        if (Vector3.Distance(target.position, transform.position) < stopTrackRadius)
        {
            isFollowing = false;
        }
        
        transform.position = Vector3.MoveTowards(transform.position, forwardVector.position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage();
            collision.gameObject.GetComponent<PlayerHealth>().PlayExplosion();
            Destroy(gameObject);
        }
    }

    public void SetTarget(Transform tr)
    {
        target = tr;
        isFollowing = true;
    }
}
