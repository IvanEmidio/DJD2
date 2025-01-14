using UnityEngine;

public class PickUpClass : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private LayerMask pickupLayer;
    [SerializeField] private LayerMask noteLayer;
    [SerializeField] private float pickupRange = 3f;
    [SerializeField] private Transform hand;

    private Rigidbody currentObjectRigidBody;
    private Collider currentObjectCollider;

    [SerializeField] private GameObject noteCanvas; // Reference to the canvas for the note
    private bool isReadingNote = false; // Track if the player is reading a note

    void Start()
    {
        noteCanvas.SetActive(false); // Ensure the canvas is hidden at the start
    }

    void Update()
    {
        // Check if the player is reading a note and presses space to close it
        if (isReadingNote && Input.GetKeyDown(KeyCode.Space))
        {
            CloseNote();
            return; // Exit Update to avoid further input checks
        }

        // Handle picking up objects
        if (Input.GetKeyDown(KeyCode.E) && !isReadingNote)
        {
            Ray pickupRay = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
            if (Physics.Raycast(pickupRay, out RaycastHit hitInfo, pickupRange, pickupLayer))
            {
                if (hitInfo.rigidbody != null)
                {
                    if (currentObjectRigidBody != null)
                    {
                        DropObject();
                    }

                    PickUpObject(hitInfo.rigidbody);
                }
            }
            else if (currentObjectRigidBody != null)
            {
                DropObject();
            }
        }

        // Handle interacting with notes
        if (Input.GetMouseButtonDown(0) && !isReadingNote)
        {
            Ray interactRay = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
            if (Physics.Raycast(interactRay, out RaycastHit hitInfo, pickupRange, noteLayer))
            {
                if (hitInfo.collider.CompareTag("Note"))
                {
                    ShowNote();
                }
            }
        }

        // Keep the picked-up object in the player's hand
        if (currentObjectRigidBody != null)
        {
            currentObjectRigidBody.position = hand.position;
            currentObjectRigidBody.rotation = hand.rotation;
        }
    }

    private void PickUpObject(Rigidbody rigidBody)
    {
        currentObjectRigidBody = rigidBody;
        currentObjectCollider = rigidBody.GetComponent<Collider>();

        currentObjectRigidBody.isKinematic = true;
        currentObjectCollider.enabled = false;

        currentObjectRigidBody.transform.parent = hand;
        currentObjectRigidBody.transform.localPosition = Vector3.zero;
        currentObjectRigidBody.transform.localRotation = Quaternion.identity;

        Debug.Log($"Picked up object: {rigidBody.name}");
    }

    private void DropObject()
    {
        currentObjectRigidBody.isKinematic = false;
        currentObjectCollider.enabled = true;

        currentObjectRigidBody.transform.parent = null;

        Debug.Log($"Dropped object: {currentObjectRigidBody.name}");

        currentObjectRigidBody = null;
        currentObjectCollider = null;
    }

    private void ShowNote()
    {
        noteCanvas.SetActive(true); // Show the note canvas
        Time.timeScale = 0f; // Pause the game to allow reading
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        isReadingNote = true; // Set the flag indicating the player is reading a note

        Debug.Log("Reading note...");
    }

    public void CloseNote()
    {
        noteCanvas.SetActive(false); // Hide the note canvas
        Time.timeScale = 1f; // Resume the game
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        isReadingNote = false; // Reset the flag

        Debug.Log("Closed note.");
    }
}
