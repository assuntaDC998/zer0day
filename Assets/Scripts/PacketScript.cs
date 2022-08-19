using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PacketScript : MonoBehaviour
{
    [SerializeField] public string type;
    [SerializeField] public string malwareType;
    [SerializeField] protected Transform destination;
    private NavMeshAgent agent;

    public static explicit operator PacketScript(GameObject v)
    {
        throw new NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = destination.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            agent.destination = destination.position;

    }
}