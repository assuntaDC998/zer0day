using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;


public class DraggableComponent : MonoBehaviour, IInitializePotentialDragHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    private RectTransform rectTransform;
    private Canvas canvas;
    private GameObject duplicate;
    private Vector3 startPosition;
    

    public bool FollowCursor { get; set; } = true;
    public Vector3 StartPosition;
    public bool CanDrag { get; set; } = true;


    private GameObject Duplicate() {
        GameObject duplicate = Instantiate(gameObject);
        duplicate.transform.SetParent(gameObject.transform.parent);

        RectTransform dRT = duplicate.GetComponent<RectTransform>();
        dRT.anchoredPosition = rectTransform.anchoredPosition;
        dRT.offsetMin = rectTransform.offsetMin;
        dRT.offsetMax = rectTransform.offsetMax;
        dRT.position = rectTransform.position;
        dRT.rotation = rectTransform.rotation;
        duplicate.transform.localScale = rectTransform.localScale;
        return duplicate;
    }

    public void OnBeginDrag(PointerEventData data){
        if (!CanDrag) return;
        duplicate = Duplicate();

    }

    public void OnDrag(PointerEventData data)
    {
        if (!CanDrag) return;
        if (FollowCursor) rectTransform.anchoredPosition += data.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData data)
    {
        if (!CanDrag) return;
        RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000) && hit.collider!=null)
        {
            if(hit.collider.gameObject.GetComponent<DropArea>()!=null)
                hit.collider.gameObject.GetComponent<DropArea>().onDrop(gameObject);
        }
        resetDrop(data);

    }

    private void resetDrop(PointerEventData data) {
        Destroy(duplicate);
        rectTransform.anchoredPosition = StartPosition;
    }

    public void OnInitializePotentialDrag(PointerEventData data)
    {
        StartPosition = rectTransform.anchoredPosition;
    }

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GameObject.Find("GameUI").GetComponent<Canvas>();
        startPosition = rectTransform.position;
    }


}