using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Camera _mainCamera;
    private Camera _receivedCamera;
    public bool _isOnMain;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _mainCamera = GetComponent<Camera>();
        _mainCamera.enabled = true;
        _isOnMain = true;
    }

    // Update is called once per frame
    public void TurnOn()
    {
        _mainCamera.enabled = true;
        _isOnMain = true;
    }

    public void TurnOff()
    {
        _mainCamera.enabled = false;
        _isOnMain = false;
        
    }
}
