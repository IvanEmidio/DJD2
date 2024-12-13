using UnityEngine;

public class AltCamera : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;
    [SerializeField]
    private CameraManager _mainCamera;

    void Start()
    {
        _camera.enabled = false;
    }
    public void ActivateCamera()
    {
        _camera.enabled = true;
        _mainCamera.TurnOff();
    }

    public void DeactivateCamera()
    {
        _camera.enabled = false;
        _mainCamera.TurnOn();
    }

}
