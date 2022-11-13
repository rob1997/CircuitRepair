using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndGate : Gate
{
    public override bool Solve(bool[] input)
    {
        Input = input;

        Output = Input[0] && Input[1];

        return Output;
    }
}
