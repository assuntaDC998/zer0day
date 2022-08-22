using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;


public class DraggableComponent : MonoBehaviour, IInitializePotentialDragHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
 
    public event Action<PointerEventData> OnBeginDragHandler;
    public event Action<PointerEventData> OnDragHandler;
    public event Action<PointerEventData, bool> OnEndDragHandler;

    private RectTransform rectTransform;
    private Canvas canvas;
    private GameObject duplicate;

    public bool FollowCursor { get; set; } = true;
    public Vector3 StartPosition;
    public bool CanDrag { get; set; } = true;


    public void OnBeginDrag(PointerEventData data){
        if (!CanDrag) return;
        duplicate = Instantiate(gameObject, rectTransform, false);
        duplicate.transform.SetParent(gameObject.transform.parent);
        duplicate.SetActive(true);

        OnBeginDragHandler?.Invoke(data);
    }

    public void OnDrag(PointerEventData data)
    {
        if (!CanDrag) return;
        OnDragHandler?.Invoke(data);
        if (FollowCursor) rectTransform.anchoredPosition += data.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData data)
    {
        if (!CanDrag) return;
        /*var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(data, results);
        DropArea dropArea = null;
        foreach (var result in results) {
            dropArea = result.gameObject.GetComponent<DropArea>();
            if (dropArea != null) break;
        }

        Debug.Log(dropArea == null);

        if (dropArea != null)
        {
             if (dropArea.Accepts(this))
            {
                dropArea.Drop(this);
                OnEndDragHandler?.Invoke(data, true);
                return;
            }
        }*/

        RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000) && hit.collider!=null)
        {
            // TO ADAPT
            if (hit.collider.gameObject.CompareTag("Laptop"))
            {
                rectTransform.position = hit.point;
            }
            else
                failDrop(data);
        }
        else
            failDrop(data);

    }

    private void failDrop(PointerEventData data) {
        Destroy(duplicate);
        rectTransform.anchoredPosition = StartPosition;
        OnEndDragHandler?.Invoke(data, false);
    }

    public void OnInitializePotentialDrag(PointerEventData data)
    {
        StartPosition = rectTransform.anchoredPosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GameObject.Find("GameUI").GetComponent<Canvas>();
    }


}
