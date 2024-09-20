using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerSpeed = 5;
    [SerializeField] float turnSpeed = 5;
    [SerializeField] float jumpForce = 10;
    [SerializeField] Transform forwardVector;
    [SerializeField] Transform raycastVector;
    //[SerializeField] Vector3 raycastDirection = new Vector3(0, 180, 45);
    [SerializeField] LayerMask layerMask;
    [SerializeField] GameObject pausePanel;

    private Rigidbody rb;

    public bool isGrounded;
    public bool isDying = false;
    public Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDying && !LevelManager.Instance.isInCountdown)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
            }

            if ((Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl)) && isGrounded)
            {
                playerAnimator.SetTrigger("Throw");
                PlaceBomb();
                AudioManager.Instance.PlayBombPlant();
            }

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                playerAnimator.SetTrigger("Jump");
                rb.useGravity = true;
                rb.AddForce(Vector3.up * jumpForce);
                AudioManager.Instance.StopSkating();
                AudioManager.Instance.PlayJump();
            }

            transform.position = Vector3.MoveTowards(transform.position, forwardVector.position, playerSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            pausePanel.SetActive(true);
            GameManager.Instance.PauseGame();
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tile") && !isGrounded)
        {
            isGrounded = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tile"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tile"))
        {
            isGrounded = false;
        }
    }

    void PlaceBomb()
    {

        RaycastHit hit;
        Vector3 raycastDirection = raycastVector.position - transform.position;
        //Debug.DrawRay(transform.position, raycastDirection * 10, Color.red);

        int maskNumber = LayerMask.NameToLayer("Default");
        maskNumber = ~maskNumber;

        if (Physics.Raycast(transform.position, raycastDirection, out hit, 10, layerMask))
        {
            Debug.Log("Hmmm?");
            if (hit.transform.gameObject.CompareTag("Tile"))
            {
                //Debug.DrawRay(transform.position, raycastDirection * hit.distance, Color.yellow);
                //Debug.Log("Did Hit");
                hit.transform.gameObject.GetComponent<TileParentCaller>().CallParentSpawnFunction();
            }
        }
        else
        {
            Debug.Log("No hit");
        }
    }         
}
