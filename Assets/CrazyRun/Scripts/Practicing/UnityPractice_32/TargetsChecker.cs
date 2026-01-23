using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TargetsChecker : MonoBehaviour
{
    public GameObject[] Clients;
    private int newLength;
    [SerializeField] private Vector3 scale;

    [SerializeField] private GameObject zoneCheck;
    [SerializeField] private LayerMask layerMask;

    public void CastTargetsChecker()
    {
        Collider[] AllTargets = Physics.OverlapBox(zoneCheck.transform.position, scale, Quaternion.identity, layerMask);
        newLength = AllTargets.Length;
        Clients = new GameObject[newLength];
        CheckTargets(AllTargets);
    }

    private void CheckTargets(Collider[] AllTargets)
    {
        for (int i = 0; i < AllTargets.Length; i++)
        {
            Clients[i] = AllTargets[i].gameObject;
        }

    }

}
