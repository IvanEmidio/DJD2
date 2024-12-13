using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CanvasManager : MonoBehaviour
{
    private Image _image;
    [SerializeField]
    private CameraManager _cameraManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (Transform child in transform)
        {
            _image = child.GetComponent<Image>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(_cameraManager._isOnMain)
        {
            _image.enabled = true;
        }
        else
        {
            _image.enabled = false;
        }
    }
}
