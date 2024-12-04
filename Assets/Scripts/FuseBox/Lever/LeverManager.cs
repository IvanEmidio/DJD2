using UnityEngine;
using System;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine.UIElements;

public class LeverManager : MonoBehaviour
{
    private Lever _lever; // Value to assign to each child
    private bool done = false;

    void Start()
    {
        foreach (Transform child in transform)
        {
            Lever lever = child.GetComponent<Lever>();
            if (lever != null)
            {
                _lever = lever;
            }
        }
    }

    public bool GetFuseState()
    {
        return _lever.GetLeverBool();
    }
}