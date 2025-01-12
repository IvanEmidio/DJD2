using UnityEngine;
using System;
using System.Collections.Generic;

public class LeverManager : MonoBehaviour
{
    [SerializeField]
    private FuseManager _fuseManager;
    [SerializeField]
    private ShaderModifierScript _shaderManager;
    private Lever _lever; // Value to assign to each child

    void Start()
    {
        foreach (Transform child in transform)
        {
            PivotScript pivot = child.GetComponent<PivotScript>();
            if (pivot != null)
            {
                _lever = pivot.GetChild(typeof(Lever)) as Lever;
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
            else
            {
                print("Inside");
                _shaderManager.NotNeon();
            }
        }
    }
    /* public bool GetFuseState()
    {
        return _lever.GetLeverBool();
    } */
}