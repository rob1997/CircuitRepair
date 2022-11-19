using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dock : MonoBehaviour
{
    public CircuitComponent CircuitComponent;

    public Socket Socket;

    public float value;
    
    public float goal;

    public Image socketImage;
    
    public void Connect(Socket socket)
    {
        Socket = socket;

        value = socket != null ? socket.value : 0;

        if (CircuitComponent != null)
        {
            CircuitComponent.Solve();
            
            AudioSource.PlayClipAtPoint(socket != null ? AudioManager.Instance.slottedSound : AudioManager.Instance.unSlottedSound, Vector3.zero);
        }

        else
        {
            socketImage.enabled = Socket != null;

            if (Math.Abs(value - goal) < .05f)
            {
                Map.Instance.CheckGoals();
            }
            
            AudioSource.PlayClipAtPoint(socket != null ? AudioManager.Instance.slottedSound2 : AudioManager.Instance.unSlottedSound, Vector3.zero);
        }
    }
}
