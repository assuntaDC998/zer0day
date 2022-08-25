using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PacketController : MonoBehaviour
{
    [SerializeField] public string type;
    [SerializeField] public string malwareType;
    [SerializeField] protected Transform destination;
    private NavMeshAgent agent;
    public LevelController levelController; 

    // Start is called before the first frame update
    void Start()
    {
        levelController = GameObject.Find("Levelcontroller").GetComponent<LevelController>();
        agent = GetComponent<NavMeshAgent>();
        agent.destination = destination.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            agent.destination = destination.position;

    }

    public void Accept() {
        // FIX WITH PACKET TYPE DATA
        levelController.ModifyCoin(1);
        levelController.ModifyDataToComplete(1);
    }


}