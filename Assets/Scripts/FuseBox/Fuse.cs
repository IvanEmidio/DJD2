using UnityEngine;
using System;

public class Fuse : MonoBehaviour
{
    private bool _state = false; 

    public void SetFuseState(bool state)
    {
        _state = state;
    }

    private void OnMouseDown()
    {
        _state = !_state;
        Debug.Log($"{gameObject.name} was clicked! fuseValue is now {_state}");
    }

    public bool GetFuseBool()
    {
        return _state;
    }
}