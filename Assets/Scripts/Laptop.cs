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
        coll.gameObject.SetActive(false);
        Debug.Log(coll.gameObject.tag + " collided with " + this.name);
        coll.gameObject.transform.position = GameObject.Find("OvestLaptop").transform.position;
        coll.gameObject.SetActive(true);
    }

}
