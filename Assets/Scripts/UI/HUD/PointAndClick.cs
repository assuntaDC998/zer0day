using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
                    GameObject laptop = hit.transform.gameObject;
                    if (laptop.CompareTag("Laptop"))
                    {
                        //oppure invocare un evento passando gameObject come argomento
                        //GameObject.Find("GameUI").transform.Find("PauseMenu").gameObject.SetActive(true);
                    }
                }
            }      
        }
    }
}
