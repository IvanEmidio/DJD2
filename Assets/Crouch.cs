using UnityEngine;

public class Crouch : MonoBehaviour
{
    public CapsuleCollider playerCollider;
    public Rigidbody playerRigidbody;

    public float crouchSpeed;
    public float normalHeight;
    public float crouchHeight;
    
    private bool crouching;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            crouching = !crouching;
        }

        AdjustCrouch();
    }

    private void AdjustCrouch()
    {
        // Target height based on crouching state
        float targetHeight = crouching ? crouchHeight : normalHeight;
    
        // Smoothly adjust collider height
        playerCollider.height = Mathf.Lerp(playerCollider.height, targetHeight, crouchSpeed * Time.deltaTime);
    
        // Adjust collider center to keep the bottom of the collider grounded
        playerCollider.center = new Vector3(0, playerCollider.height / 2, 0);
    }
}