using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController_30 : MonoBehaviour
{
    private Vector2 newGravity = new Vector2(0, 0);

    public Vector2 GetTouchDeltaPosition()
    {
        if (IsThereTouchOnScreen() == true)
        {
            if (Input.GetTouch(0).deltaPosition.x > 5)
            {
                newGravity.x = 10;
            }
            else if (Input.GetTouch(0).deltaPosition.x < -5)
            {
                newGravity.x = -10;
            }

            if (Input.GetTouch(0).deltaPosition.y > 5)
            {
                newGravity.y = 10;
            }
            else if (Input.GetTouch(0).deltaPosition.y < -5)
            {
                newGravity.y = -10;
            }
            
            return newGravity;
        }
        else return Vector2.zero;
    }

    public bool IsThereTouchOnScreen()
    {
        if (Input.touchCount > 0)
        {
            return true;
        }
        else return false;
    }
}
