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

    public bool GetFuseState(int index)
    {
        return _lever.GetLeverBool();
    }

    public bool GetPuzzleDone()
    {
        if(_fuses[0].GetFuseBool() && !_fuses[1].GetFuseBool() && _fuses[2].GetFuseBool() && !_fuses[3].GetFuseBool())
        {
            done = true;
            return done;
        }
            
        return done;
    }
}