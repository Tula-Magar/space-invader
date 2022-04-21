using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectile;

    private float movementDirection;

    private float movementDirectionVertical;
    private float timerShoot;
    private float xRange = 8.4f;

    //movement speed in units per second
    private float movementSpeed = 5f;

    void Start()
    {

    }

    void Update()
    {
        timerShoot += Time.deltaTime;

        CheckOutOfBounds();

        if (Input.GetButton("Jump") && (timerShoot > 0.2f))
        { // keyword for spacebar
            Instantiate(projectile, transform.position, projectile.transform.rotation);
            timerShoot = 0;
        }
    }

    void FixedUpdate()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.position = transform.position + new Vector3(horizontalInput * movementSpeed * Time.deltaTime, verticalInput * movementSpeed * Time.deltaTime, 0);


    }

    private void CheckOutOfBounds()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector2(-xRange, transform.position.y);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector2(xRange, transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy_Projectile"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Enemy")) { Destroy(gameObject); }
    }
}
