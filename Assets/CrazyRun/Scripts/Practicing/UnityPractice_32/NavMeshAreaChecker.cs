using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAreaChecker : MonoBehaviour
{
    private NavMeshAgent agent;
    private NavMeshSurface surface;
    private float distance =  1f;

    public float currentArea;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void CheckArea()
    {
        NavMeshHit hit;

        if (NavMesh.SamplePosition(agent.transform.position, out hit, distance, NavMesh.AllAreas))
        {

            if (hit.mask == 8)
            {
                currentArea = 3;
            }
            else if (hit.mask == 16)
            {
                currentArea = 4;
            }
            else if (hit.mask == 32)
            {
                currentArea = 5;
            }
        }
    }


}
