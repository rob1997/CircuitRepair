using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dragger : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    #region Dragged

    public delegate void Dragged(PointerEventData eventData);

    public event Dragged OnDragged;

    private void InvokeDragged(PointerEventData eventData)
    {
        OnDragged?.Invoke(eventData);
    }

    #endregion

    #region BeginDragged

    public delegate void BeginDragged(PointerEventData eventData);

    public event BeginDragged OnBeginDragged;

    private void InvokeBeginDragged(PointerEventData eventData)
    {
        OnBeginDragged?.Invoke(eventData);
    }

    #endregion

    #region EndDragged

    public delegate void EndDragged(PointerEventData eventData);

    public event EndDragged OnEndDragged;

    private void InvokeEndDragged(PointerEventData eventData)
    {
        OnEndDragged?.Invoke(eventData);
    }

    #endregion


    private Vector3 _initialPosition;
    
    private Vector3 _offset;

    private RectTransform _rectT;
    
    private void Start()
    {
        _rectT = GetComponent<RectTransform>();
        
        _initialPosition = transform.localPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(_rectT, eventData.position, eventData.pressEventCamera, out var globalMousePosition))
        {
            _rectT.position = globalMousePosition - _offset;
        }
        
        InvokeDragged(eventData);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(_rectT, eventData.position, eventData.pressEventCamera, out var globalMousePosition))
        {
            _offset = globalMousePosition - transform.position;
        }
        
        InvokeBeginDragged(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        InvokeEndDragged(eventData);
    }
    
    public void ResetPosition()
    {
        transform.localPosition = _initialPosition;
    }
}
