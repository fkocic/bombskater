using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehaviour : MonoBehaviour
{
    [SerializeField] float bombLife = 5;
    [SerializeField] float playerSaveTime = 0.5f;
    [SerializeField] ParticleSystem explosion;
    [SerializeField] GameObject bombModel;

    private float counter;
    private MeshRenderer meshRenderer;
    private SphereCollider sphereCollider;


    private void Start()
    {
        counter = bombLife;
        meshRenderer = GetComponent<MeshRenderer>();
        sphereCollider = GetComponent<SphereCollider>();
    }

    void Update()
    {
        if (counter <= 0) StartCoroutine(Boom());
        if (playerSaveTime > 0) playerSaveTime -= Time.deltaTime;

        counter -= Time.deltaTime;
    }

    private void Explode()
    {
        transform.parent.GetComponent<TileBehaviour>().DestroyTile();      
        Destroy(gameObject);
    }

    IEnumerator Boom()
    {
        explosion.Play();
        AudioManager.Instance.PlayExplosion();
        transform.parent.GetComponent<TileBehaviour>().DestroyTile();
        //meshRenderer.enabled = false;
        bombModel.SetActive(false);
        sphereCollider.enabled = false;

        yield return new WaitForSeconds(2);

        Destroy(gameObject);
    }

    IEnumerator BigBoom()
    {
        explosion.transform.localScale *= 2;
        explosion.Play();
        AudioManager.Instance.PlayExplosion();
        //meshRenderer.enabled = false;
        bombModel.SetActive(false);
        sphereCollider.enabled = false;

        yield return new WaitForSeconds(2);

        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && playerSaveTime <= 0)
        {
            other.gameObject.GetComponent<PlayerHealth>().Die();
            //Explode();
            StartCoroutine(Boom());
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyHealth>().Die();
            //Explode();
            StartCoroutine(Boom());
        }

        if (other.gameObject.CompareTag("Enemy Tank"))
        {
            other.gameObject.GetComponent<EnemyHealth>().TankDie();
            //Explode();
            //Destroy(gameObject);
            StartCoroutine(BigBoom());
        }
    }
}
