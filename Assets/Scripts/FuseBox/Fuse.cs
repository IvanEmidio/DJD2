using UnityEngine;
using System;

public class Fuse : MonoBehaviour
{
    private bool _state = false; 
    private AnimationManager _animator;

    void Start()
    {
        _animator = GetComponent<AnimationManager>();
    }
    public void SetFuseState(bool state)
    {
        _state = state;
    }

    private void OnMouseDown()
    {
        _state = !_state;
        if(_state)
        {
            _animator.PlayAnimation("TurnOn");
        }
        else
        {
            _animator.PlayAnimation("TurnOff");
        }
    }

    public bool GetFuseBool()
    {
        return _state;
    }

    public void TurnOff()
    {
        if(_state)
        {
            _animator.PlayAnimation("TurnOff");
        }
        _state = false;
        
    }
}