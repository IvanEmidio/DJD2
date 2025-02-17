using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float senX;
    public float senY;

    public Transform orientation;

    float xRotation;
    float yRotation;
    private CameraManager cameraManager;


    private void Start()
    {
      Cursor.lockState = CursorLockMode.Locked;
      Cursor.visible = false;
      cameraManager = GetComponent<CameraManager>();
    }
   private void Update()
   {
      float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * senX;
      float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * senY;

      yRotation += mouseX;

      xRotation -= mouseY;

      xRotation = Mathf.Clamp(xRotation, -90f, 90f);

      transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
      orientation.rotation = Quaternion.Euler(0, yRotation, 0);

      if(cameraManager._isOnMain)
      {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
      }
      else
      {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
      }
   }
}
