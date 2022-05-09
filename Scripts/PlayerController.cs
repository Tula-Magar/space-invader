using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject projectile;
    public GameObject explosion;

    private float movementDirection;
    private float timerMove;
    private float timerShoot;
    private float xRange = 8.4f;
    private bool callOnce;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        callOnce = true;
    }

    void Update()
    {
        timerMove += Time.deltaTime;
        timerShoot += Time.deltaTime;

        CheckOutOfBounds();
        
        // 'Jump' is the keyword for spacebar
        // if exceeding cooldown and not already one projectile on screen, create a projectile for the player
        if (Input.GetButton("Jump") && (timerShoot > 0.2f) && !GameObject.Find("Player_Projectile(Clone)")) {
            Instantiate(projectile, transform.position, projectile.transform.rotation);
            timerShoot = 0;
        }
    }

    // FixedUpdate() is used to prevent stuttering due to Unity and frame timing shenanigans
    void FixedUpdate()
    {
        movementDirection = Input.GetAxisRaw("Horizontal"); // range from -1 to 1 (left to right)

        // timer tacks performance to timer, not computer power
        if (timerMove >= 0.01f) {
            if (movementDirection == 1) { // right
                transform.position = new Vector2(transform.position.x + 0.2f, transform.position.y);
            } else if (movementDirection == -1) { // left
                transform.position = new Vector2(transform.position.x - 0.2f, transform.position.y);
            }

            timerMove = 0;
        }
    }

    // keeps player from leaving screen by locking them in to the xRange
    private void CheckOutOfBounds()
    {
        if (transform.position.x < -xRange) {
            transform.position = new Vector2(-xRange, transform.position.y); }

        if (transform.position.x > xRange) {
            transform.position = new Vector2(xRange, transform.position.y); }
    }

    // Unity's MonoBehaviour does the heavy lifting here
    // only difference between two if statements is whether or not to destroy other.gameObject
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy_Projectile")) {
            Destroy(other.gameObject);
            gameManager.PlayerDied();
            Destroy(Instantiate(explosion, transform.position, transform.rotation), 0.2f);
            Destroy(gameObject);
        }

        if (callOnce) { // call only one time even multiple enemies collide with player 
            if (other.gameObject.CompareTag("Enemy")) {
                gameManager.PlayerDied();
                Destroy(Instantiate(explosion, transform.position, transform.rotation), 0.2f);
                Destroy(gameObject);
                callOnce = false;  
            }
        } else { callOnce = true;}
    }
}
