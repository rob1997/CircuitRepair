using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotGate : Gate
{
    public override bool Solve(bool[] input)
    {
        Input = input;

        Output = !Input[0];
        
        return Output;
    }
}
