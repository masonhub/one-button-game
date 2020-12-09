using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    private Rigidbody2D rigidbody2d;
    public float moveForce = 5f;

    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    
    {
        rigidbody2d.AddForce(Vector2.right*moveForce, ForceMode2D.Force);

    }
}