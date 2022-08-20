using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Laptop : MonoBehaviour
{
    [SerializeField]
    public GameObject startPoint;

    protected DropArea DropArea;

    void Start()
    {


    }

    void Update()
    {
        
    }

    protected virtual void Awake()
    {
        DropArea = GetComponent<DropArea>() ?? gameObject.AddComponent<DropArea>();
        DropArea.OnDropHandler += OnItemDropped;
    }

    private void OnItemDropped(DraggableComponent draggable) {
        draggable.transform.position = transform.position;
    }


    private void OnCollisionEnter(Collision coll)
    {
        coll.gameObject.SetActive(false);
        Debug.Log(coll.gameObject.tag + " collided with " + this.name);
        coll.gameObject.transform.position = startPoint.transform.position;
        coll.gameObject.SetActive(true);
    }

}
