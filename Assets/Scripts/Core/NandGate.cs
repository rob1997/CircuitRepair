using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NandGate : CircuitComponent
{
    protected override float GetOutput()
    {
        return Mathf.Abs(Input.Min(i => i.value) - 1f);
    }
}
