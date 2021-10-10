using System;
using System.Collections;
using System.Collections.Generic;
using Command;
using UnityEngine;
using Random = UnityEngine.Random;

public class CircleMovement : MonoBehaviour
{
    public float speed = 7.5f;

    private Rigidbody2D _rigidbody2D;
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Move()
    {
        const float initialForce = 5.0f;
        
        float random = Random.Range(-initialForce, initialForce);

        if (Random.Range(-1, 1) < 0)
        {
            _rigidbody2D.velocity = Vector2.ClampMagnitude(new Vector2(-initialForce, random), speed);
        }
        else
        {
            _rigidbody2D.velocity = Vector2.ClampMagnitude(new Vector2(initialForce, random), speed);
        }
    }

    public void Move(float x, float y)
    {
        _rigidbody2D.velocity = new Vector2(x * speed, y * speed);
    }

    public void Move(Vector2 target)
    {
        _rigidbody2D.MovePosition(Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime)); 
    }
}
