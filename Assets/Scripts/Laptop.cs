using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Laptop : MonoBehaviour
{
    [SerializeField]
    public GameObject startPoint;
    private bool antivirus;
 

    void Start()
    { 

    }

    void Update()
    {
        
    }
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
        Debug.Log(coll.gameObject.tag + " collided with " + this.name);
        coll.gameObject.transform.position = startPoint.transform.position;
        coll.gameObject.SetActive(true);
    }

    public static explicit operator Laptop(GameObject v)
    {
        throw new NotImplementedException();
    }
}

