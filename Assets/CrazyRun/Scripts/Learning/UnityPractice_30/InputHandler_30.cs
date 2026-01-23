using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler_30 : MonoBehaviour
{
    public Vector2 GetTouchDeltaPosition()
    {
        if (Input.touchCount > 0)
        {
            return Input.GetTouch(0).deltaPosition;
        }

        return Vector2.zero;
    }

    public bool IsThereTouchOnScreen()
    {
        if (Input.touchCount > 0) return true;
        else return false;
    }

    private void Update()
    {
        //Debug.Log(GetTouchDeltaPosition() + "DeltaPosition");
        //Debug.Log(IsThereTouchOnScreen() + " touch on screen");
    }
}
