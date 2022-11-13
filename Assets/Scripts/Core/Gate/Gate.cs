using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gate : MonoBehaviour
{
    public string title;
    
    [field: SerializeField] public bool[] Input { get; protected set; }

    public bool Output { get; protected set; }

    public abstract bool Solve(bool[] input);
}
