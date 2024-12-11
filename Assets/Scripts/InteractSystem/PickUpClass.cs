using UnityEngine;

public class PickUpClass : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private LayerMask pickupLayer;
    [SerializeField] private float pickupRange = 3f;
    [SerializeField] private Transform hand;

    private Rigidbody currentObjectRigidBody;
    private Collider currentObjectCollider;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
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
}
