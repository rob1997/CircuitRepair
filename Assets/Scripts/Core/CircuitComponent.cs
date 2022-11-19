using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CircuitComponent : MonoBehaviour
{
    public string title;

    [field: SerializeField] public Dock[] Input { get; protected set; }

    [field: SerializeField] public Socket Output { get; protected set; }

    protected virtual float GetOutput()
    {
        return Mathf.Clamp(Input.Sum(i => i.value), 0f, 1f);
    }
    
    public void Solve()
    {
        //has empty dock (input not full)
        if (Input.Any(i => i.Socket == null))
        {
            Output.value = 0;
            
            Output.Connect();
            
            return;
        }

        Output.value = GetOutput();
        
        if (Output.Dock != null)
        {
            Output.Connect();
        }
    }
}
