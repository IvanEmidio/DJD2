using UnityEngine;
using System;
using System.Collections.Generic;

public class LeverManager : MonoBehaviour
{
    [SerializeField]
    private FuseManager _fuseManager;
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

    void Update()
    {
        if(_lever.GetLeverBool())
        {
            _fuseManager.GetPuzzleDone();
            if(!_fuseManager.GetPuzzleState())
            {
                _lever.ResetLever();
                _fuseManager.TurnAllOff();
            }
        }
    }
    /* public bool GetFuseState()
    {
        return _lever.GetLeverBool();
    } */
}