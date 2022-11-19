using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Outlet : MonoBehaviour
{
    public Toggle on;
    
    public Socket Socket;
    
    void Start()
    {
        on.onValueChanged.AddListener(isOn =>
        {
            Socket.value = isOn ? 1 : 0;
            
            Socket.Connect();
        });

        on.isOn = Socket.value > 0;
    }
}
