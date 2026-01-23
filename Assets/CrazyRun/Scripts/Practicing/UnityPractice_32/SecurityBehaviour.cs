using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.AI;

public class SecurityBehaviour : MonoBehaviour
{
    private NavMeshAgent agent;

    private GameObject[] possibleTargets;
    private int newLength;

    private TargetsChecker targetsChecker;

    [SerializeField] private GameObject chillZone;

    public Vector3 targetPos;
    private bool UpdateStopper = false;
    [SerializeField] private bool IsTargetChosen = true;
    private bool checkDistance = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        targetsChecker = GetComponent<TargetsChecker>();
        StartCoroutine(ChillOnSpot());

    }

    private void FixedUpdate()
    {
        if (!UpdateStopper)
        {
            StartCoroutine(CheckForUpdate());
        }

        if (!IsTargetChosen)
        {
            IsTargetChosen = true;
            ChooseTarget();
        }
        else if (IsTargetChosen && checkDistance)
        {
            FollowTarget();

            if (Vector3.Distance(agent.transform.position, agent.destination) <= 1.35f)
            {
                checkDistance = false;
                agent.destination = chillZone.transform.position;
                StartCoroutine(ChillOnSpot());
            }

        }
    }

    private void GetTargetsPool()
    {
        targetsChecker.CastTargetsChecker();
        newLength = targetsChecker.Clients.Length;

        possibleTargets = new GameObject[newLength];

        for (int i = 0; i < possibleTargets.Length; i++)
        {
            possibleTargets[i] = targetsChecker.Clients[i];
        }

        UpdateStopper = false;
    }

    private void ChooseTarget()
    {
        if (possibleTargets.Length != 0)
        {
            int targetID = Random.Range(0, possibleTargets.Length);
            targetPos = possibleTargets[targetID].transform.position;
            Debug.Log(possibleTargets[targetID]);
            checkDistance = true;
        }
        else
        {
            StartCoroutine(ChillOnSpot());
        }

    }

    private void FollowTarget()
    {
        if (Vector3.Distance(agent.transform.position, agent.destination) < 8)
        {
            agent.destination = targetPos;
            Debug.Log(Vector3.Distance(agent.transform.position, agent.destination));
        }
        else
        {
            targetPos = chillZone.transform.position;
            agent.destination = targetPos;
        }
    }

    private IEnumerator CheckForUpdate()
    {
        UpdateStopper = true;
        yield return new WaitForSeconds(2);
        GetTargetsPool();
        
    }

    private IEnumerator ChillOnSpot()
    {
        float waitingTime = Random.Range(2, 8);
        yield return new WaitForSeconds(waitingTime);
        IsTargetChosen = false;
    }


}
