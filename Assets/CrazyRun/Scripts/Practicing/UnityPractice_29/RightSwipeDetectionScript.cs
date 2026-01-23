using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightSwipeDetectionScript : MonoBehaviour
{
    public float xpos1;
    public float xpos2;
    public float ypos1;
    public float ypos2;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                xpos1 = touch.position.x;
                ypos1 = touch.position.y;
                //Debug.Log("стартовое положение = " + touch.position);
            }
            if (touch.phase == TouchPhase.Moved)
            {
              xpos1 = touch.position.x;
            }
            if (touch.phase == TouchPhase.Ended)
            {
                xpos2 = touch.position.x;
                ypos2 = touch.position.y;
                //Debug.Log("конечное положение = " + touch.position);
            }


            if (touch.deltaPosition.x > 0)
            {
                if (xpos2 - xpos1 >= 100)
                {
                    if (Math.Abs(ypos2 - ypos1) < 50)
                    {
                        Debug.Log("Свайп вправо!");
                    }
                }
            }
        }
    }
}
