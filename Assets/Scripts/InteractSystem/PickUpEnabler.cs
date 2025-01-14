using UnityEngine;

public class PickUpEnabler : MonoBehaviour
{
    void Start()
    {
        gameObject.layer = 0;
    }
    public void CanGrab()
    {
        gameObject.layer = 6; // Disable the collider
    }
}
