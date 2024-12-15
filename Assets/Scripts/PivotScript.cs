using System;
using UnityEngine;

public class PivotScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Component GetChild(Type Component)
    {
        foreach (Transform child in transform)
        {
            var component = child.GetComponent(Component);
            if(component != null)
            {
                return component;
            }
        }
        return null;
    }
}
