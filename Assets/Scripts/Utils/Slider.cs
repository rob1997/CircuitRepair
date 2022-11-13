using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Slider : MonoBehaviour
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    public Direction direction;

    private RectTransform _rectT;

    private void Awake()
    {
        _rectT = GetComponent<RectTransform>();
    }

    public void Slide(float distance, float duration = .25f)
    {
        _rectT.DOComplete();

        Vector2 anchorPos = _rectT.anchoredPosition;

        switch (direction)
        {
            case Direction.Up:
                anchorPos.y += distance;
                break;
            case Direction.Down:
                anchorPos.y -= distance;
                break;
            case Direction.Left:
                anchorPos.x -= distance;
                break;
            case Direction.Right:
                anchorPos.x += distance;
                break;
        }

        _rectT.DOAnchorPos(anchorPos, duration);
    }
}
