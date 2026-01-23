using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomDetectionScript : MonoBehaviour
{
    private Touch touch1;
    //private Touch touch2;

    private float distance;
    private float previousDistance;



    

    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch1 = Input.GetTouch(0);
            //touch2 = Input.GetTouch(1);

            Vector2 prev_pos1 = touch1.position - touch1.deltaPosition;

            Vector2 pos1 = touch1.position;
            //Vector2 pos2 = touch2.position;
            Vector2 pos2 = new Vector2(500, 500);

            previousDistance = Vector2.Distance(pos2, prev_pos1);
            distance = Vector2.Distance(pos2, pos1);


            if (touch1.phase == TouchPhase.Moved)
            {
                if (distance - previousDistance > 0)
                {
                    Debug.Log("Жест увеличение");
                }
            }


        }

    }
}
