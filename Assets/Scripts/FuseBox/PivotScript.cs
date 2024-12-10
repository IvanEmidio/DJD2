using UnityEngine;

public class PivotScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Fuse GetChild()
    {
        foreach (Transform child in transform)
        {
            Fuse fuse = child.GetComponent<Fuse>();
            return fuse;
        }
        return null;
    }
}
