using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public int direction;
    private float yRange = 6.0f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + (direction * 0.05f));

        if (Mathf.Abs(transform.position.y) > yRange) { Destroy(gameObject); }
    }
}
