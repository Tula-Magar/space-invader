using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    // public GameObject projectile;

    public float movementDirection;
    private float timerShoot;
    private float xRange = 8.4f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timerShoot += Time.deltaTime;

        CheckOutOfBounds();

        if (movementDirection == 1)
        { // right
            transform.position = new Vector2(transform.position.x + 0.2f, transform.position.y);
            timerShoot = 0;
        }
        else if (movementDirection == -1)
        { // left
            transform.position = new Vector2(transform.position.x - 0.2f, transform.position.y);
            timerShoot = 0;
        }
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
}
