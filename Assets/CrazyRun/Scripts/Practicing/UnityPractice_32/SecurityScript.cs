
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class SecurityScript : MonoBehaviour
{
    [SerializeField] private GameObject[] clientsInZone;
    [SerializeField] private int SecurityZone;

    private NavMeshAgent agent;
    private int targetID;
    private Vector3 targetPos;
    [SerializeField] private bool updateTargetPos = true;
    [SerializeField] private bool checkDistance = false;
    //private bool targetChosen = false;

    [SerializeField] private GameObject chosenclient;

    private NavMeshAreaChecker areaChecker;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        clientsInZone = GameObject.FindGameObjectsWithTag("Client");
    }

    void Update()
    {
        if (updateTargetPos)
        {
            updateTargetPos = false;
            ChoseTarget();
            
        }

        if (checkDistance && !updateTargetPos)
        {
            agent.destination = targetPos;

            if (areaChecker.currentArea == SecurityZone)
            {
                if (agent.remainingDistance <= 1)
                {
                    checkDistance = false;
                    //targetChosen = false;
                    StartCoroutine(ChillOnSpot());

                }
            }
            else
            {
                checkDistance = false;
                StartCoroutine(ChillOnSpot());
            }
            
        }

    }

    private IEnumerator ChillOnSpot()
    {
        //float waitingTime = Random.Range(1, 8);
        yield return new WaitForSeconds(1);
        Debug.Log("Снова выбирает");
        updateTargetPos = true;
    }

    private IEnumerator WaitForDestinationCheck()
    {
        yield return new WaitForSeconds(0.1f);
        checkDistance = true;
    }

    private void ChoseTarget()
    {
        Debug.Log("Выбирает клиента");
        targetID = Random.Range(0, 5);
        int i = targetID;
        targetPos = clientsInZone[i].transform.position;
        chosenclient = clientsInZone[i];
        areaChecker = chosenclient.GetComponent<NavMeshAreaChecker>();
        areaChecker.CheckArea();
        Debug.Log(chosenclient.name);
        Debug.Log(areaChecker.currentArea);

        if (areaChecker.currentArea == SecurityZone)
        {
            Debug.Log("Пошел осматривать");
            //targetChosen = true;
            StartCoroutine(WaitForDestinationCheck());

        }
        else
        {
            Debug.Log("Пошел курить");
            ChillOnSpot();
        }
    }

}
