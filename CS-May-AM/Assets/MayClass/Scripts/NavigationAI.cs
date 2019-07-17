using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationAI : MonoBehaviour
{
    public Transform chasee;
    private NavMeshAgent ghostAgent;

    void Start()
    {
        ghostAgent = GetComponent<NavMeshAgent>();
    }
    
    void Update()
    {
        ghostAgent.SetDestination(chasee.position);
    }
}
