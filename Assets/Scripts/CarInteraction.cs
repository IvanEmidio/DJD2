using UnityEngine;

public class CarInteraction : MonoBehaviour
{
    [SerializeField] private string requiredItemTag = "Tire"; // Tag for the required item (e.g., "Tire")
    [SerializeField] private Transform hand; // Reference to the hand transform
    [SerializeField] private GameObject objectToActivate; // Object to activate when the correct item is used

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button click
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                // Check if the clicked object is this car
                if (hitInfo.collider.gameObject == gameObject)
                {
                    Debug.Log("Car clicked!");

                    if (hand.childCount > 0)
                    {
                        Transform heldItem = null;

                        // Iterate through the children of the hand and find the correct item
                        foreach (Transform child in hand)
                        {
                            if (child.name != "cube" && child.CompareTag(requiredItemTag))
                            {
                                heldItem = child;
                                break;
                            }
                        }

                        if (heldItem != null)
                        {
                            Debug.Log($"Holding correct object: {heldItem.name}");

                            // Remove the held item and activate the object
                            Destroy(heldItem.gameObject);
                            if (objectToActivate != null)
                            {
                                objectToActivate.SetActive(true);
                            }
                        }
                        else
                        {
                            Debug.Log("No correct item held, or only 'cube' is in hand.");
                        }
                    }
                    else
                    {
                        Debug.Log("No object is being held.");
                    }
                }
            }
        }
    }
}
