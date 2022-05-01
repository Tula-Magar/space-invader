using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject projectile;

    private float movementDirection;
    private float timerMove;
    private float timerShoot;
    private float xRange = 8.4f;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        timerMove += Time.deltaTime;
        timerShoot += Time.deltaTime;

        CheckOutOfBounds();
        
        // 'Jump' is the keyword for spacebar
        if (Input.GetButton("Jump") && (timerShoot > 0.2f) && !GameObject.Find("Player_Projectile(Clone)")) {
            Instantiate(projectile, transform.position, projectile.transform.rotation);
            timerShoot = 0;
        }
    }

    void FixedUpdate()
    {
        movementDirection = Input.GetAxisRaw("Horizontal"); // fixes jitter movement bug

        if (timerMove >= 0.01f) {
            if (movementDirection == 1) { // right
                transform.position = new Vector2(transform.position.x + 0.2f, transform.position.y);
            } else if (movementDirection == -1) { // left
                transform.position = new Vector2(transform.position.x - 0.2f, transform.position.y);
            }

            timerMove = 0;
        }
    }

    private void CheckOutOfBounds()
    {
        if (transform.position.x < -xRange) {
            transform.position = new Vector2(-xRange, transform.position.y); }

        if (transform.position.x > xRange) {
            transform.position = new Vector2(xRange, transform.position.y); }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy_Projectile")) {
            Destroy(other.gameObject);
            gameManager.PlayerDied();
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Enemy")) {
            gameManager.PlayerDied();
            Destroy(gameObject);
        }
    }
}
