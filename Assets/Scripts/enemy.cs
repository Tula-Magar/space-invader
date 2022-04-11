using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject projectile;
    private float timerShoot;
    private float xRange = 8.4f;

    float timer = 0;
    float timeToMove = 0.5f;
    int numofMovements = 0;
    float speed = 3.2f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timerShoot += Time.deltaTime;

        CheckOutOfBounds();

        // if (movementDirection == 1)
        // { // right
        //     transform.position = new Vector2(transform.position.x + 0.2f, transform.position.y);
        //     // timerShoot = 0;
        // }
        // if (movementDirection == -1)
        // { // left
        //     transform.position = new Vector2(transform.position.x - 0.2f, transform.position.y);
        //     // timerShoot = 0;
        // }

        if (numofMovements == 3)
        {
            transform.Translate(new Vector2(speed, 0));
            numofMovements = -1;
            speed = -speed;
            timer = 0;
            Instantiate(projectile, transform.position, projectile.transform.rotation);
            timerShoot = 0;
        }

        timer += Time.deltaTime;
        if (timer > timeToMove && numofMovements < 3)
        {
            transform.Translate(new Vector2(speed, 0));

            timer = 0;
            numofMovements++;
            Instantiate(projectile, transform.position, projectile.transform.rotation);
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

    // https://youtu.be/2mNXfrh0UYo
}
