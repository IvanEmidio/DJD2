using UnityEngine;

public class ActivateCanvasOnObjects : MonoBehaviour
{
    [SerializeField] private GameObject object1; 
    [SerializeField] private GameObject object2; 
    [SerializeField] private GameObject canvasToShow; 

    private bool object1Activated = false;
    private bool object2Activated = false;

    void Start()
    {
        canvasToShow.SetActive(false); 
    }

    void Update()
    {
        // Check if object1 and object2 are active
        if (object1.activeSelf && !object1Activated)
        {
            object1Activated = true;
            Debug.Log("Object 1 activated");
        }

        if (object2.activeSelf && !object2Activated)
        {
            object2Activated = true;
            Debug.Log("Object 2 activated");
        }

        // Show the canvas when both objects are activated
        if (object1Activated && object2Activated)
        {
            ShowCanvas();
        }
    }

    private void ShowCanvas()
    {
        canvasToShow.SetActive(true); 
        Debug.Log("Both objects activated, showing canvas.");
        enabled = false; 
        Time.timeScale = 0f; // Pause the game to allow reading
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        End();
    }

    private void End()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Application.Quit();
        }
    }
}
