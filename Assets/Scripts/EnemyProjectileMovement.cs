using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileMovement : MonoBehaviour
{
    public int direction;
    public float speed;
    private float yRange = -6.0f;

    void Start()
    {

    }

    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + (direction * speed));

        if (Mathf.Abs(transform.position.y) > yRange) { Destroy(gameObject); }
    }
}
