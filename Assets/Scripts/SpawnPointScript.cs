using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnPointScript : MonoBehaviour
{
    public GameObject Bot;
    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        if (Bot.GetComponent<NavMeshAgent>() != null)
            navMeshAgent = Bot.GetComponent<NavMeshAgent>();
    }

    public NavMeshAgent GetNavMeshAgent
    {
        get
        {
            if(navMeshAgent!=null)
                return navMeshAgent;
            return null;
        }
    }
}
