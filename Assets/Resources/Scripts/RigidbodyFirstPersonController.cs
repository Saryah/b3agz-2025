using UnityEngine;

public class RigidbodyFirstPersonController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 3f;
    public float crouchSpeed = 1.5f;
    public float jumpForce = 5f;
    public float sprintSpeed;

    [Header("Crouch Settings")]
    public Vector3 standingScale = new Vector3(0.75f, 0.75f, 0.75f); // Player scale when standing
    public Vector3 crouchingScale = new Vector3(0.75f, 0.5f, 0.75f); // Player scale when crouching
    public float crouchTransitionSpeed = 5f;
    
    [Header("Mouse Settings")]
    public float mouseSensitivity = 2f;

    private Rigidbody _rb;
    public Camera cam;
    private bool _isCrouching = false;
    private bool _isSprinting = false;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform cameraTransform;
    private float _xRotation = 0f;

    private void Awake()
    {
        // Set the initial scale immediately in Awake
        transform.localScale = standingScale;
        
        //Locates Camera
        
    }
    private void Start()
    {
        
        //Set Camera
        cam = Camera.main;
        
        _rb = GetComponent<Rigidbody>();

        // Lock the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Freeze unwanted rotations
        _rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    private void Update()
    {
        if (GameManager.instance is not null && GameManager.instance.inMenu)
        {
            return;
        }
        MovePlayer();
        HandleJump();
        LookAround();
        HandleCrouch();
        HandleSprint();
    }

    void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.tag == "Room")
        {
            RoomMessage.instance.isRiddle = true;
            RoomMessage.instance.riddle1 = other.gameObject.GetComponent<Room>().riddle.riddleLine1;
            RoomMessage.instance.riddle2 = other.gameObject.GetComponent<Room>().riddle.riddleLine2;
            RoomMessage.instance.riddle3 = other.gameObject.GetComponent<Room>().riddle.riddleLine3;
            RoomMessage.instance.riddle4 = other.gameObject.GetComponent<Room>().riddle.riddleLine4;
        }*/

        
    }

    void OnTriggerStay(Collider other)
    {
        
    }

    void OnTriggerExit(Collider other)
    {
        //if(other.gameObject.tag == "Room")
            //RoomMessage.instance.isRiddle = false;
    }
    
    
    private void LookAround()
    {
      // Rotation
		Vector2 mouseDelta = mouseSensitivity * new Vector2(Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y"));
		Quaternion rotation = cam.transform.rotation;
		Quaternion horiz = Quaternion.AngleAxis(mouseDelta.x, Vector3.up);
		Quaternion vert = Quaternion.AngleAxis(mouseDelta.y, Vector3.right);
		cam.transform.rotation = horiz * rotation * vert;
    }
    
    private void MovePlayer()
    {
        // Get movement input
        float moveX = Input.GetAxis("Horizontal"); // A/D for strafing
        float moveZ = Input.GetAxis("Vertical");   // W/S for forward/backward

        // Calculate movement direction relative to where the player is looking
        Vector3 moveDirection = cam.transform.right * moveX + cam.transform.forward * moveZ;
        float speed = _isCrouching ? crouchSpeed: _isSprinting ? sprintSpeed : moveSpeed;

        // Apply movement
        Vector3 velocity = moveDirection.normalized * speed;
        Vector3 currentVelocity = _rb.linearVelocity;
        _rb.linearVelocity = new Vector3(velocity.x, currentVelocity.y, velocity.z);
    }

    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        }
    }

    private bool IsGrounded()
    {
        // Simple ground check
        return Physics.Raycast(transform.position, Vector3.down, 1.2f);
    }

    private void HandleCrouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            _isCrouching = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            _isCrouching = false;
        }

        // Smoothly interpolate between standing and crouching scales
        Vector3 targetScale = _isCrouching ? crouchingScale : standingScale;
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * crouchTransitionSpeed);
    }
    private void HandleSprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _isSprinting = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _isSprinting = false;
        }
    }
}