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
    private LevelController levelController; 
    private MalwareController malware;

    // Start is called before the first frame update
    void Start()
    {
        levelController = GameObject.Find("LevelController").GetComponent<LevelController>();
        agent = GetComponent<NavMeshAgent>();
        agent.destination = destination.position;

        //specify malware type 
        gameObject.AddComponent<VirusController>(); 
        malware = gameObject.GetComponent<MalwareController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            agent.destination = destination.position;

    }

    public void Accept(GameObject laptop) {
        // FIX WITH PACKET TYPE DATA
        levelController.ModifyCoin(1);
        levelController.ModifyDataToComplete(1);
        if(malware!=null)
            malware.InvokeBehaviour(laptop);
    }


}