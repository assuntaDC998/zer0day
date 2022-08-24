using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class LaptopController : InfrastructureController
{
    [SerializeField]
    public GameObject startPoint;
    private bool antivirus;

    public void addAntivirus() { 
    
    
    }

    // to generalize
    public bool requestSetAntivirus() {

        if (!antivirus) {
            antivirus = true;
            setAntivirus(); //???
            return true;
        }
        return false;
    }

    private void setAntivirus() {
        Debug.Log("Antivirus Added on " + gameObject.name);
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = gameObject.transform.position;
        sphere.transform.localScale = gameObject.transform.localScale;
        sphere.GetComponent<MeshRenderer>().material = (Material)Resources.Load("DocumentMaterial");
    }

    private void OnCollisionEnter(Collision coll)
    {
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
