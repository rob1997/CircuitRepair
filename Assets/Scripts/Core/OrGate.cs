using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OrGate : CircuitComponent
{
    protected override float GetOutput()
    {
        return Input.Max(i => i.value);
    }
}
