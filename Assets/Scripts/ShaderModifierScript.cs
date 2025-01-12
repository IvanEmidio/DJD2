using UnityEngine;

public class ShaderModifierScript : MonoBehaviour
{
    [SerializeField] private Material _originalMaterial; // The original material
    [SerializeField] private Material _newMaterial;      // The new material to switch to
    private Renderer objectRenderer;                   // The Renderer of the GameObject

    void Start()
    {
        // Get the Renderer component
        objectRenderer = GetComponent<Renderer>();

        // Set the material to the originalMaterial at the start if provided
        if (objectRenderer != null && _originalMaterial != null)
        {
            objectRenderer.material = _newMaterial;
        }
    }

    public void NotNeon()
    {
        if (objectRenderer != null && _newMaterial != null)
        {
            objectRenderer.material = _newMaterial;
        }
    }

    public void Neon()
    {
        if (objectRenderer != null && _originalMaterial != null)
        {
            objectRenderer.material = _originalMaterial;
        }
    }
}
