using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotGate : CircuitComponent
{
    protected override float GetOutput()
    {
        return Mathf.Abs(Input[0].value - 1f);
    }
}
