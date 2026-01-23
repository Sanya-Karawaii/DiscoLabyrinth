using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHandler_30 : MonoBehaviour
{
    public InputHandler_30 inputHandler;

    [SerializeField]private float ballSpeed;

    void Start()
    {
        if (inputHandler == null) 
        {
            Debug.LogError("InputHandler не назначен");
        }
    }

    private void MoveBall()
    {
        if (inputHandler.IsThereTouchOnScreen())
        {
            Vector2 currDeltaPos = inputHandler.GetTouchDeltaPosition();
            currDeltaPos = currDeltaPos * ballSpeed;
            Vector3 newGravityVector = new Vector3(currDeltaPos.x, Physics.gravity.y, currDeltaPos.y);
            Physics.gravity = newGravityVector;
            Debug.Log(newGravityVector);
        }
    }

    void Update()
    {
        MoveBall();
        
    }
}
