using System;
using System.Collections;
using System.Collections.Generic;
using Manager;
using UnityEngine;

public class EnemyCircleController : MonoBehaviour
{
    public CircleMovement circleMovement;
    public PlayerCircleController playerCircle;

    private Vector2 _targetPos;
    private float _trackingCooldown = 0.3f;
    private float _trackingTimer;

    private void Start()
    {
        circleMovement = GetComponent<CircleMovement>();
        playerCircle = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCircleController>();
        
        _targetPos = playerCircle.transform.position;
        _trackingTimer = 0.0f;
    }

    private void FixedUpdate()
    {
        _trackingTimer += Time.deltaTime;
        if (_trackingTimer >= _trackingCooldown)
        {
            _targetPos = playerCircle.transform.position;
            _trackingTimer = 0.0f;
        }
        
        circleMovement.Move(_targetPos);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
