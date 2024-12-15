using UnityEngine;
using System;

public class Lever : MonoBehaviour
{
    private bool _clicked = false; 
    private AnimationManager _animator;

    void Start()
    {
        _animator = GetComponent<AnimationManager>();
    }

    private void OnMouseDown()
    {
        if(!_clicked)
        {
            _clicked = !_clicked;
            _animator.PlayAnimation("TurnOn");
        }
    }

    public bool GetLeverBool()
    {
        return _clicked;
    }

    public void ResetLever()
    {
        _clicked = false;
        _animator.PlayAnimation("TurnOff");
    }
}