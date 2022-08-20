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

    public bool FollowCursor { get; set; } = true;
    public Vector3 StartPosition;
    public bool CanDrag { get; set; } = true;


    public void OnBeginDrag(PointerEventData data){
        if (!CanDrag) return;
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
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(data, results);
        DropArea dropArea = null;
        foreach (var result in results) {
            dropArea = result.gameObject.GetComponent<DropArea>();
            if (dropArea != null) break;
        }
        if (dropArea != null)
        {
            if (dropArea.Accepts(this))
            {
                dropArea.Drop(this);
                OnEndDragHandler?.Invoke(data, true);
                return;
            }
        }
        // failed drop
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
