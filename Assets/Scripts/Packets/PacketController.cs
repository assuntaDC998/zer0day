using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PacketController : Component
{
    [SerializeField] public string type;
    [SerializeField] public string malwareType = "";
    [SerializeField] protected Transform destination;
    private NavMeshAgent agent;
    private LevelController levelController; 
    private MalwareController malware;
    

    // Start is called before the first frame update
   public override void Start()
    {

        levelController = GameObject.Find("LevelController").GetComponent<LevelController>();
        agent = GetComponent<NavMeshAgent>();
        agent.destination = destination.position;

        //specify malware type 
       // gameObject.AddComponent<VirusController>(); 
        //malware = gameObject.GetComponent<MalwareController>();
    }

    // Update is called once per frame
    public override void Update()
    {
        //Debug.Log(features.);
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            agent.destination = destination.position;

    }

    public void Accept(GameObject laptop) {
        // FIX WITH PACKET TYPE DATA
        Debug.Log("Packet Coins: " + (int)features[PacketsFeatures.PacketFeature.FeatureType.FT_VALUE].currentValue);
        levelController.ModifyCoin((int)features[PacketsFeatures.PacketFeature.FeatureType.FT_VALUE].currentValue);
        levelController.ModifyLevelCompletion((int)features[PacketsFeatures.PacketFeature.FeatureType.FT_WEIGHT].currentValue);
        if(malware!=null)
            malware.InvokeBehaviour(laptop);
    }

    public override void Awake()
    {
        base.Awake();
    }

    public override void setFeatures()
    {
        //
    }

    public override void initializeFeatures()
    {
        //
    }
}