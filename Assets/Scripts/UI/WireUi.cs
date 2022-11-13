using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Wire))]
public class WireUi : MonoBehaviour
{
    public Connection Connection;

    public Wire Wire;
    
    private void Awake()
    {
        Connection = GetComponent<Connection>();

        Wire = GetComponent<Wire>();
    }

    private void Update()
    {
        foreach (var point in Connection.points)
        {
            point.color = Wire.Value ? Map.Instance.onColor : Map.Instance.offColor;
        }
    }
}
