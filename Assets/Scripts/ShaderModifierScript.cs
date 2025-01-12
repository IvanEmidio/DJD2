using UnityEngine;

public class ShaderModifierScript : MonoBehaviour
{
    public void ChangeEmissionValue(int index, bool on, Color color)
    {
        Renderer renderer = GetComponent<Renderer>();

        if (renderer != null)
        {
            Material[] materials = renderer.materials;

            if (index >= 0 && index < materials.Length)
            {
                Material material = materials[index];

                if (material.HasProperty("_EmissionColor"))
                {
                    // Set the emission color to black (stops the glow)
                    if(on)
                    {
                        material.SetColor("_EmissionColor", Color.black);
                    }
                    else
                    {
                        material.SetColor("_EmissionColor", color);
                    }
                    
                }
            }
        }
    }
}
