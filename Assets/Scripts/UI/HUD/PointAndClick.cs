using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndClick : MonoBehaviour
{

    private ShopManager shopManager;
    // Start is called before the first frame update
    void Start()
    {
        shopManager = GameObject.Find("ShopManager").GetComponent<ShopManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetMouseButtonDown(0) ){
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 200f))
            {
                if (hit.transform != null)
                {
                    GameObject pointed = hit.transform.gameObject;
                    Debug.Log("CLick " + pointed.tag);
                    if (pointed.CompareTag("Defense"))
                    {
                        shopManager.openShop(pointed.tag);
                    }
                }
            }      
        }
    }
}
