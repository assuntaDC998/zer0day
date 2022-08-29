using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
 

public class LaptopController : InfrastructureController
{
    [SerializeField]
    public GameObject startPoint;

    private void OnCollisionEnter(Collision coll)
    {
        System.Random rnd = new System.Random();
        PacketController packet = coll.gameObject.GetComponent<PacketController>();
        if (packet.malwareType == "")
        {
            if (falsePositives < rnd.Next(100) / 100)
            {
                //Accept a benign packet
                packet.Accept(gameObject);
            }
        }
        else {
            // Accept a malware container packet
            if (efficiency < rnd.Next(100) / 100)
            {
                packet.Accept(gameObject);
            }
        }

        //Recycle packets -- TO ADAPT
        coll.gameObject.SetActive(false);
        coll.gameObject.transform.position = startPoint.transform.position;
        coll.gameObject.SetActive(true);
    }

    public override void Awake()
    {
        base.Awake();

        string featuresFile = new StreamReader("Assets/PushToData/Features/Infrastructures/laptop.json").ReadToEnd();
        mapper = JsonUtility.FromJson<InfrastructuresFeaturesJsonMap>(featuresFile);
        this.features = mapper.todict();
    }

    public override void Update()
    {
        base.Update();
    }

}
