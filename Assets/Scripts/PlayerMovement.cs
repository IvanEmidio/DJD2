using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]AudioSource audfootsteps;
    [SerializeField]private CameraManager cameraCheck;
    public float moveSpeed;

    public float groundDrag;

    public Transform orientation;

    

    [Header("Ground Check")]

    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;
   
   [Header("Crouch Control")]

    public float crouchSpeed;

    public float crouchYScale;

    private float startYScale;

    [Header("Keybinds")]

    public KeyCode crouchKey = KeyCode.C;


    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    public MovementState state;
    public enum MovementState
    {
        crouching
    }

    private void Start()
    {
        audfootsteps = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        startYScale = transform.localScale.y;
    }

    private void Update()
    {
        //GroundCheck
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        MyInput();
        SpeedControl();
        StateHandler();

        //Handle drag

        if(grounded)
            rb.linearDamping = groundDrag;
        else 
            rb.linearDamping = 0;
            
        

    }

    private void StateHandler()
    {
        if(Input.GetKey(crouchKey))
        {
            state = MovementState.crouching;
            moveSpeed = crouchSpeed;
        }
    }

    private void FixedUpdate()
    {
        if(cameraCheck._isOnMain)
            MovePlayer();
    }

    private void MyInput()
    {
        
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");


        //start crouch

        if(Input.GetKeyDown(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
        }

        //stop crouch
        if(Input.GetKeyUp(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
        }
    }

    private void MovePlayer()
    {
        
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        if (moveDirection!= new Vector3(0,0,0))
            {
                if (!audfootsteps.isPlaying)
                audfootsteps.Play();
            }
            if(moveDirection==new Vector3(0,0,0))
            {
                audfootsteps.Stop();
            }
        
    }

    private void SpeedControl()
    {
        
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        if(flatVel.magnitude > moveSpeed)
        {
            
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
            
            
            

        }
    }
}
