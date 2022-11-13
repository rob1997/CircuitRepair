using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slot))]
public class SlotUi : MonoBehaviour
{
    public Slot Slot;

    public Image GoalImage;
    
    private void Awake()
    {
        Slot = GetComponent<Slot>();
    }

    public bool Solve(Gate gate, out string message)
    {
        return Slot.Solve(gate, out message);
    }

    public void TurnGoalOn(bool value)
    {
        GoalImage.enabled = true;
            
        GoalImage.color = value ? Map.Instance.onColor : Map.Instance.offColor;
    }
}
