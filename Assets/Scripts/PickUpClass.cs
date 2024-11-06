using UnityEngine;

public class PickUpClass : MonoBehaviour
{

    [SerializeField] Camera playerCamera;
    [SerializeField] private LayerMask pickupLayer;
    [SerializeField] private float pickupRange;

    [SerializeField] private Transform hand;

    private Rigidbody currentObjectRigidBody;

    private Collider currentObjectCollider;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
        Ray pickupRay = new Ray (playerCamera.transform.position, playerCamera.transform.forward);

            if(Physics.Raycast(pickupRay, out RaycastHit hitInfo, pickupRange))
            {
                if(currentObjectRigidBody)
                {
                    currentObjectRigidBody.isKinematic = false;
                    currentObjectCollider.enabled = true;

                    currentObjectRigidBody = hitInfo.rigidbody;
                    currentObjectCollider = hitInfo.collider;

                    currentObjectRigidBody.isKinematic = true;
                    currentObjectCollider.enabled = false;
                }
                else
                {
                    currentObjectRigidBody = hitInfo.rigidbody;
                    currentObjectCollider = hitInfo.collider;

                    currentObjectRigidBody.isKinematic = true;
                    currentObjectCollider.enabled = false;
                }

                return;
            }   

            if(currentObjectRigidBody)
                {
                    currentObjectRigidBody.isKinematic = false;
                    currentObjectCollider.enabled = true;

                    currentObjectRigidBody = null;
                    currentObjectCollider = null;
                }  
        }

        

        if(currentObjectRigidBody)
        {
            currentObjectRigidBody.position = hand.position;
            currentObjectRigidBody.rotation = hand.rotation;
        }
    }
}
