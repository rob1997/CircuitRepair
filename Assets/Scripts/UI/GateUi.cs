using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Gate))]
public class GateUi : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Gate Gate;
    
    public Slot Slot;

    private Vector3 _initialPosition;

    private CanvasGroup _canvasGroup;

    private Camera _camera;
    
    private RectTransform _rectT;
    
    private void Awake()
    {
        Gate = GetComponent<Gate>();

        _canvasGroup = GetComponent<CanvasGroup>();

        _rectT = GetComponent<RectTransform>();
    }

    private void Start()
    {
        _camera = Camera.main;
        
        _initialPosition = transform.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = false;

        if (Slot != null)
        {
            Slot.Solve(null, out string message);

            Slot = null;
            
            Debug.Log(message);
            
            AudioSource.PlayClipAtPoint(AudioManager.Instance.unSlottedSound, Vector3.zero);
        }
        
        AudioSource.PlayClipAtPoint(AudioManager.Instance.unSlottedSound2, Vector3.zero);
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(_rectT, eventData.position, eventData.pressEventCamera, out var globalMousePosition))
        {
            _rectT.position = globalMousePosition;
        }
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject != null && eventData.pointerCurrentRaycast.gameObject.TryGetComponent(out SlotUi slotUi))
        {
            if (slotUi.Solve(Gate, out string message))
            {
                transform.position = slotUi.transform.position;

                Slot = slotUi.Slot;
                
                AudioSource.PlayClipAtPoint(AudioManager.Instance.slottedSound, Vector3.zero);
            }

            else
            {
                ResetPosition();
                
                AudioSource.PlayClipAtPoint(AudioManager.Instance.deniedSound, Vector3.zero);
            }
                
            Debug.Log(message);
        }

        else
        {
            ResetPosition();
        }
        
        _canvasGroup.blocksRaycasts = true;
    }

    private void ResetPosition()
    {
        transform.position = _initialPosition;
    }
}
