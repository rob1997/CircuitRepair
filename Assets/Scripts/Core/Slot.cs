using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public Wire[] input;
    
    public Wire output;

    [field: SerializeField] public Gate Gate { get; private set; }

    private bool CanSolve(Gate gate)
    {
        if (gate.Input.Length != input.Length) return false;

        return true;
    }
    
    public bool Solve(Gate gate, out string message)
    {
        if (gate == null)
        {
            Gate = null;
            
            message = "Null Gate Error";

            output.In(false);
            
            return false;
        }
        
        if (!CanSolve(gate))
        {
            message = "Logic Gate Inputs don't match";

            return false;
        }

        Gate = gate;

        output.In(Gate.Solve(Array.ConvertAll(input, i => i.Value)));

        message = $"{Gate.title} Gate Connected";
        
        return true;
    }
    
    public bool Solve(out string message)
    {
        if (Gate == null)
        {
            message = "Null Gate Error";

            return false;
        }
        
        if (!CanSolve(Gate))
        {
            message = "Logic Gate Inputs don't match";

            return false;
        }

        output.In(Gate.Solve(Array.ConvertAll(input, i => i.Value)));

        message = $"{Gate.title} Gate Connected";
        
        return true;
    }
}
