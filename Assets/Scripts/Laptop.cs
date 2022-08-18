using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class Laptop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision coll)
    {
        
        if (coll.gameObject.GetComponent<PacketScript>().type.Equals("Mail"))
        {
            coll.gameObject.SetActive(false);
        }
        

        //coll.gameObject.active = false;
    }

}
