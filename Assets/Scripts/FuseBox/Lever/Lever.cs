using UnityEngine;
using System;

public class Lever : MonoBehaviour
{
    private bool _clicked = false; 


    private void OnMouseDown()
    {
        _clicked = !_clicked;
    }

    public bool GetLeverBool()
    {
        return _clicked;
    }

    public void ResetLever()
    {
        _clicked = false;
    }
}