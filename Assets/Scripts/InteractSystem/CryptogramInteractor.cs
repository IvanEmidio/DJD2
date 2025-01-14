using UnityEngine;

public class CryptogramInteractor : MonoBehaviour
{
    private AltCamera _camera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _camera = GetComponent<AltCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            _camera.DeactivateCamera();
        }
    }

    private void OnMouseDown()
    {
        _camera.ActivateCamera();
    }
}
