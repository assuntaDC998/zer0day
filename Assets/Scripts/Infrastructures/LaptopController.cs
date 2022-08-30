using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
 

public class LaptopController : InfrastructureController
{
    [SerializeField]
    public GameObject startPoint;
    private bool activeAntiVirus;
    private GameObject antiVirusModel;

    private void OnCollisionEnter(Collision coll)
    {
        System.Random rnd = new System.Random();
        PacketController packet = coll.gameObject.GetComponent<PacketController>();
        if (packet.malwareType == "")
        {
            Debug.Log("IF");
            if (falsePositives <  ((float)rnd.Next(100)) / 100)
            {
                Debug.Log("Accept a benign packet");
                //Accept a benign packet
                packet.Accept(gameObject);
            }
        }
        else {
            Debug.Log("ELSE");

            // Accept a malware container packet
            if (efficiency < ((float)rnd.Next(100)) / 100)
            {
                Debug.Log("Accept a malware");
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
        activeAntiVirus = false;
        antiVirusModel = Resources.Load("Models/Defenses/AntiVirus") as GameObject;
    }

    public override void Update()
    {
        base.Update();
    }

    public override void OnDrop(GameObject dropped)
    {
        if (dropped.CompareTag("AntiVirus"))
        {
            if (!activeAntiVirus)
            {
                activeAntiVirus = true;
                createAntiVirus();
            }
            else handleElementOverflow(generateOverflowMex("AV", "AVs", 1));
            
            updateDefensesFeatures();
        }
    }

    private void createAntiVirus()
    {
        GameObject antiVirus = Instantiate(antiVirusModel);
        defenses.Add(antiVirus.GetComponent<AntiVirusController>());
        Vector3 position = gameObject.transform.position;
        antiVirus.transform.position = new Vector3(position.x - 0.66f, position.y + 0.908f, position.z - 0.48f);
        antiVirus.SetActive(true);
    }

}
