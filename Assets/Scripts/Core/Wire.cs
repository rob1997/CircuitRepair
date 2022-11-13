using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    [field: SerializeField] public Slot Input { get; set; }
    
    [field: SerializeField] public Slot Output { get; set; }

    [field: SerializeField] public bool Value { get; private set; }

    public bool isGoal;
    
    public void In(bool value)
    {
        Value = value;

        if (Output != null)
        {
            Output.Solve(out string message);
            
            Debug.Log(message);
            
            Debug.Log($"Output {value}");
        }

        else
        {
            Debug.Log($"Output {value}");

            if (isGoal)
            {
                Map.Instance.CheckGoals();
            }
        }
    }
}
