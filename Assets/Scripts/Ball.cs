using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    public float force;
    private bool isOnGround = false;
    public float jumpForce;
    public GameManager gameManager;
    public GameObject coinParticle;
    public GameObject flagParticle;
    public GameObject blueParticle;

    public bool gameStarted = false;
    public MeshRenderer meshRend;

    public Material[] ballMats;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Crystal"))
        {
            Destroy(other.gameObject);
            //print(1111);
            gameManager.lives++;
            meshRend.material = ballMats[gameManager.lives-1];
            Instantiate(blueParticle, other.gameObject.transform.position, Quaternion.identity);
        }
        if(other.CompareTag("Spike") || other.CompareTag("Water"))
        {
            gameManager.lives--;
            gameManager.Die();
            meshRend.material = ballMats[gameManager.lives - 1];
            if (gameManager.lives <= 0)
            {
                //gameManager.EndGame();
            }
        }
        if (other.CompareTag("Flag"))
        {
            gameManager.startPosition = other.transform.position;
            Instantiate(flagParticle, other.gameObject.transform.position, Quaternion.identity);
        }
        if (other.CompareTag("Coin"))
        {
            gameManager.score++;
            Destroy(other.gameObject);
            Instantiate(coinParticle, other.gameObject.transform.position, Quaternion.identity);
        }
    }

    private void Update()
    {
        RaycastHit info;
        Physics.Raycast(transform.position, Vector3.down, out info, 0.26f);
        Debug.DrawRay(transform.position, Vector3.down * 0.26f, Color.white);
        if (Physics.Raycast(transform.position, Vector3.down, out info, 0.26f))
        {
            if (info.collider.CompareTag("Ground"))
            {
                isOnGround = true;
            }
        }
        else
        {
            isOnGround = false;
        }
    }

    void FixedUpdate()
    {
        //Debug.Log(rb.velocity);
        if (!gameStarted)
            return;
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(new Vector3(-force, 0, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector3(force, 0, 0));
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(new Vector3(0, 0, force));
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(new Vector3(0, 0, -force));
        }
        if(Input.GetKey(KeyCode.Space) && isOnGround) 
        {
            rb.AddForce(new Vector3(0, jumpForce, 0));
        }
    }
}
