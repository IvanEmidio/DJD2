using UnityEngine;
using System;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine.UIElements;

public class FuseManager : MonoBehaviour
{
    private List<Fuse> _fuses = new List<Fuse>(); // Value to assign to each child
    private bool done = false;

    void Start()
    {
        foreach (Transform child in transform)
        {
            PivotScript pivot = child.GetComponent<PivotScript>();
            _fuses.Add(pivot.GetChild(typeof(Fuse)) as Fuse);
        }

        
    }

    public bool GetFuseState(int index)
    {
        return _fuses[index].GetFuseBool();
    }

    public void GetPuzzleDone()
    {
        if( (_fuses[0].GetFuseBool() == true) &&
            (_fuses[1].GetFuseBool() == false) &&
            (_fuses[2].GetFuseBool() == true) &&
            (_fuses[3].GetFuseBool() == true) &&
            (_fuses[4].GetFuseBool() == false) &&
            (_fuses[5].GetFuseBool() == true))
        {
            done = true;
        }
    }

    public bool GetPuzzleState()
    {
        return done;
    }

    public void TurnAllOff()
    {
        for (int i = 0; i < _fuses.Count; i++)
            _fuses[i].TurnOff();
    }
}