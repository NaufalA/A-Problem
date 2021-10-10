using System;
using System.Collections;
using System.Collections.Generic;
using Command;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerCircleController : MonoBehaviour
{
    public CircleMovement circleMovement;

    private void Start()
    {
        circleMovement = GetComponent<CircleMovement>();
        
        InputHandler inputHandler = GetComponent<InputHandler>();
        if (inputHandler is null || !inputHandler.enabled)
        {
            circleMovement.Move();
        }
    }
}
