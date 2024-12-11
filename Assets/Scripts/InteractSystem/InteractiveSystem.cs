using UnityEngine;

public class InteractiveSystem : MonoBehaviour
{ 
    [SerializeField] private float interactionDistance = 2;

    private void Update()
    {
        RaycastHit hit;


        if(Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance))
        {
            Interactable interactable = hit.collider.gameObject.GetComponent<Interactable>();

            if(Input.GetMouseButtonDown(0) && interactable != null)
            {
                interactable.Interact();
            }
        }

    }
}
