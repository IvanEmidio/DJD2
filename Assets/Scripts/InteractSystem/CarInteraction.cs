using UnityEngine;

public class CarInteraction : MonoBehaviour
{
    [SerializeField] private string requiredItemTag = "Tire";
    [SerializeField] private string requiredItemTag1 = "Battery";
    [SerializeField] private string requiredItemTag2 = "Engine";

    [SerializeField] private Transform hand;
    
    [SerializeField] private GameObject objectToActivate;
    [SerializeField] private GameObject objectToActivate1;
    [SerializeField] private GameObject objectToActivate2;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button click
        {
            if (Camera.main != null)
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
                                if (child.name != "cube" && (child.CompareTag(requiredItemTag) ||
                                    child.CompareTag(requiredItemTag1) ||
                                    child.CompareTag(requiredItemTag2)))
                                {
                                    heldItem = child;
                                    break;
                                }
                            }

                            if (heldItem != null)
                            {
                                Debug.Log($"Holding correct object: {heldItem.name}");

                                // Activate the corresponding object based on the tag
                                if (heldItem.CompareTag(requiredItemTag) && objectToActivate != null)
                                {
                                    objectToActivate.SetActive(true);
                                }
                                else if (heldItem.CompareTag(requiredItemTag1) && objectToActivate1 != null)
                                {
                                    objectToActivate1.SetActive(true);
                                }
                                else if (heldItem.CompareTag(requiredItemTag2) && objectToActivate2 != null)
                                {
                                    objectToActivate2.SetActive(true);
                                }

                                // Remove the held item
                                Destroy(heldItem.gameObject);
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
}
