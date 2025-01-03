using UnityEngine;

public class FillShader : MonoBehaviour
{
    public Mesh mesh;
    public float objectHeight;
    public Material mat;
    public int matIndex;

    void Start()
    {
        mesh = gameObject.GetComponent<MeshFilter>().mesh;
        mat = gameObject.GetComponent<MeshRenderer>().materials[matIndex];
    }

    void Update()
    {
        objectHeight = mesh.bounds.size.y;

        mat.SetFloat("_ObjectHeight", objectHeight);
    }
}
