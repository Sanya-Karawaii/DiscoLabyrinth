
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AgentsController : MonoBehaviour
{
    public Vector3[] possibleTarget;

    private int targetID;
    private NavMeshAgent agent;
    private Vector3 targetPos;
    private bool updateTargetPos = true;
    private bool checkDistance = false;

    private NavMeshAreaChecker areaChecker;
    [SerializeField] private Animator anim;

    private bool alreadyDanced = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        areaChecker = GetComponent<NavMeshAreaChecker>();

    }

    
    void Update()
    {
        areaChecker.CheckArea();

        if (updateTargetPos)
        {
            updateTargetPos = false;
            targetID = Random.Range(0, 21);
            int i = targetID;
            targetPos = possibleTarget[i];
            agent.destination = targetPos;

            StartCoroutine(WaitForDestinationCheck());
        }

        if (checkDistance && !updateTargetPos)
        {
            if (agent.remainingDistance <= 0.71f)
            {
                checkDistance = false;
                if (areaChecker.currentArea == 5)
                {
                    DanceOnDancefloor();
                }
                else
                {
                    StartCoroutine(ChillOnSpot());

                }
            }

        }

    }

    private void DanceOnDancefloor()
    {
        if (!alreadyDanced)
        {
            alreadyDanced = true;
            StartCoroutine(StopForDance());
        
        }
        else
        {
            StartCoroutine(ChillOnSpot());

        }

    }

    private IEnumerator ChillOnSpot()
    {
        float waitingTime = Random.Range(1, 8);
        yield return new WaitForSeconds(waitingTime);
        updateTargetPos = true;
    }

    private IEnumerator WaitForDestinationCheck()
    {
        yield return new WaitForSeconds(0.1f);
        checkDistance = true;
    }

    private IEnumerator StopForDance()
    {
        anim.SetBool("BeginDance", true);
        float dancingTime = Random.Range(3, 12);
        yield return new WaitForSeconds(dancingTime);
        anim.SetBool("BeginDance", false);
        updateTargetPos = true;
        yield return new WaitForSeconds(20);
        alreadyDanced = false;
    }

}
