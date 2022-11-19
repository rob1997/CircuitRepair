using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class XnorGate : CircuitComponent
{
    protected override float GetOutput()
    {
        return Mathf.Abs((Input.Max(i => i.value) - Input.Min(i => i.value)) - 1f);
    }
}
