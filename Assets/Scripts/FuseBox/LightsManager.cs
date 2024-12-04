using UnityEngine;
using System;
using System.Collections.Generic;
public class LightsManager : MonoBehaviour
{
    [SerializeField]
    private FuseManager fuseManager; 

    [SerializeField]
    private Material greenMaterial; 

    [SerializeField]
    private Material redMaterial; 

    private Renderer modelRenderer;
    private Material[] currentMaterials; 
    private List<int> lista = new List<int>{2, 10, 3, 12, 4, 9};
    private List<int> lista2 = new List<int>{5, 6, 7, 8, 11, 13};
    
    void Start()
    {
        
        modelRenderer = GetComponent<Renderer>();

        currentMaterials = modelRenderer.materials;

    }

    void Update()
    {
        for (int i = 0; i < 6; i++)
        {
            // Check the state of the corresponding fuse
            if (fuseManager.GetFuseState(i) == true)
            {
                // Change the material to green if the fuse is active
                currentMaterials[lista[i]] = greenMaterial;
            }
            else
            {
                // Change the material to red if the fuse is inactive
                currentMaterials[lista[i]] = redMaterial;
            }
        }
    }

    void Checking()
    {
        
    }
}
