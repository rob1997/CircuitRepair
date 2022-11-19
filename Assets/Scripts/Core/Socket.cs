using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Socket : MonoBehaviour
{
    public CircuitComponent CircuitComponent;
    
    public Dock Dock;

    public float value;

    public Dragger Dragger;

    public Connection connection;
    
    private Image _image;
    
    private Transform _parent;
    
    private void Start()
    {
        Dragger = GetComponent<Dragger>();
        
        Dragger.OnBeginDragged += OnBeginSocketDrag;
        Dragger.OnEndDragged += OnEndSocketDrag;

        _image = GetComponent<Image>();

        _parent = transform.parent;
    }

    public void Connect()
    {
        if (Dock != null)
        {
            Dock.Connect(this);
        }
    }
    
    public void Connect(Dock dock)
    {
        Dock = dock;
        
        dock.Connect(this);
    }
    
    public void Disconnect()
    {
        if (Dock != null) Dock.Connect(null);
        
        Dock = null;
    }
    
    private void Update()
    {
        foreach (var point in connection.points)
        {
            point.color = value > 0 ? Map.Instance.onColor : Map.Instance.offColor;
        }
    }

    public void OnBeginSocketDrag(PointerEventData eventData)
    {
        if (Dock != null)
        {
            Disconnect();
        }
        
        transform.SetParent(_parent);
        
        transform.SetAsLastSibling();

        //make visible
        Color color = _image.color;

        color.a = 1;

        _image.color = color;
        
        //make rayCasts pass through to detect docks
        _image.raycastTarget = false;
        
        AudioSource.PlayClipAtPoint(AudioManager.Instance.clickSound2, Vector3.zero);
    }
    
    public void OnEndSocketDrag(PointerEventData eventData)
    {
        //object hit
        if (eventData.pointerCurrentRaycast.gameObject != null &&
            //dock hit
            eventData.pointerCurrentRaycast.gameObject.TryGetComponent(out Dock dock) && 
            //empty dock
            dock.Socket == null && 
            //not own dock
            (CircuitComponent == null || !CircuitComponent.Input.Contains(dock)))
        {
            var dockTransform = dock.transform;
            
            transform.position = dock.CircuitComponent != null ? dockTransform.position : dock.socketImage.transform.position;
            
            transform.SetParent(dockTransform);
            
            transform.SetAsLastSibling();
            
            Connect(dock);
            
            //make invisible
            Color color = _image.color;

            color.a = 0;

            _image.color = color;
        }

        else
        {
            Dragger.ResetPosition();
            
            AudioSource.PlayClipAtPoint(AudioManager.Instance.deniedSound, Vector3.zero);
        }
        
        //make draggable
        _image.raycastTarget = true;
    }
}
