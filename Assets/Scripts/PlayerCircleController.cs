using Command;
using UnityEngine;

public class PlayerCircleController : MonoBehaviour
{
    public CircleMovement circleMovement;
    public ZoomMovement zoomMovement;

    private void Start()
    {
        circleMovement = GetComponent<CircleMovement>();
        zoomMovement = GetComponent<ZoomMovement>();
        
        InputHandler inputHandler = GetComponent<InputHandler>();
        if (inputHandler is null || !inputHandler.enabled)
        {
            circleMovement.Move();
        }
    }

    private void OnDisable()
    {
        Debug.Log("ded");
        // TODO: Implement Game over
    }
}
