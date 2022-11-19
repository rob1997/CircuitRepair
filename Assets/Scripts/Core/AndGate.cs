using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AndGate : CircuitComponent
{
    protected override float GetOutput()
    {
        return Input.Min(i => i.value);
    }
}
