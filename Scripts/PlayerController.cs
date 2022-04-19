using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectile;

    private float movementDirection;
    private float timerShoot;
    private float xRange = 8.4f;

    void Start()
    {
        
    }

    void Update()
    {
        timerShoot += Time.deltaTime;

        CheckOutOfBounds();
        
        if (Input.GetButton("Jump") && (timerShoot > 0.2f)) { // keyword for spacebar
            Instantiate(projectile, transform.position, projectile.transform.rotation);
            timerShoot = 0;
        }
    }

    void FixedUpdate()
    {
        movementDirection = Input.GetAxisRaw("Horizontal"); // fixes jitter movement bug

        if (movementDirection == 1) { // right
            transform.position = new Vector2(transform.position.x + 0.2f, transform.position.y);
        } else if (movementDirection == -1) { // left
            transform.position = new Vector2(transform.position.x - 0.2f, transform.position.y);
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
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Enemy")) { Destroy(gameObject); }
    }
}
