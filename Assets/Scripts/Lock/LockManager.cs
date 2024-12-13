using UnityEngine;

public class LockManager : MonoBehaviour
{
    private AltCamera _camera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _camera = GetComponent<AltCamera>();
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        _camera.ActivateCamera();
    }

    void Update() 
    {
        // Check if the space key is pressed 
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            _camera.DeactivateCamera();
        } 
    }
}
