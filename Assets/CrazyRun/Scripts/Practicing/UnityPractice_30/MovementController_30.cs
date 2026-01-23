using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class MovementController_30 : MonoBehaviour
{
    public InputController_30 inputCont;
    public AudioSource moveSound;

    private Vector2 currDeltaPos;
    private Vector3 newGravityVector;

    private Vector3 origGravity = new Vector3(0, -10, 0);


    [SerializeField] private float ballspeed;
    
    private void Start()
    {
        if (inputCont == null) Debug.LogError("InputController не назначен");
    }
    private void MoveBall()
    {
        if (inputCont.IsThereTouchOnScreen())
        {
            StartCoroutine(ResetGravity());
            moveSound.Play();
            currDeltaPos = inputCont.GetTouchDeltaPosition();
            currDeltaPos = currDeltaPos * ballspeed;
            newGravityVector = new Vector3(currDeltaPos.x, Physics.gravity.y, currDeltaPos.y);
            Physics.gravity = newGravityVector;

        }
    }

    void Update()
    {
        MoveBall();
    }

    private IEnumerator ResetGravity()
    {
        yield return new WaitForSeconds(0.5f);
        Physics.gravity = origGravity;
    }
}
