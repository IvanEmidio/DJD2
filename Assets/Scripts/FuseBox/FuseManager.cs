using UnityEngine;
using System;
using System.Collections.Generic;

public class FuseManager : MonoBehaviour
{
    private List<Fuse> _fuses = new List<Fuse>(); // Value to assign to each child
    private bool done = false;

    void Start()
    {
        foreach (Transform child in transform)
        {
            Fuse fuse = child.GetComponent<Fuse>();
            if (fuse != null)
            {
                _fuses.Add(fuse);
            }
        }
    }

    public bool GetFuseState(int index)
    {
        return _fuses[index].GetFuseBool();
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