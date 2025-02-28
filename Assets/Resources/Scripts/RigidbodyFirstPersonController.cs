using UnityEngine;

public class RigidbodyFirstPersonController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float crouchSpeed = 2.5f;
    public float jumpForce = 5f;

    [Header("Mouse Settings")]
    public float mouseSensitivity = 2f;

    [Header("Crouch Settings")]
    public Vector3 standingScale = new Vector3(0.75f, 0.75f, 0.75f); // Player scale when standing
    public Vector3 crouchingScale = new Vector3(0.75f, 0.5f, 0.75f); // Player scale when crouching
    public float crouchTransitionSpeed = 5f;

    private Rigidbody _rb;
    [SerializeField] private Transform cameraTransform;
    private float _xRotation = 0f;
    private bool _isCrouching = false;
    [SerializeField] private LayerMask groundLayer;

    private void Awake()
    {
        // Set the initial scale immediately in Awake
        transform.localScale = standingScale;
        
        //Locates Camera
        
    }
    private void Start()
    {
        
        
        _rb = GetComponent<Rigidbody>();

        // Lock the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Freeze unwanted rotations
        _rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    private void Update()
    {
        
        LookAround();
        HandleCrouch();
    }

    [System.Obsolete]
    private void FixedUpdate()
    {
        MovePlayer();
        HandleJump();
    }

    private void LookAround()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotate the player horizontally
        transform.Rotate(Vector3.up * mouseX);

        // Rotate the camera vertically
        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
    }

    [System.Obsolete]
    private void MovePlayer()
    {
        // Get movement input
        float moveX = Input.GetAxis("Horizontal"); // A/D for strafing
        float moveZ = Input.GetAxis("Vertical");   // W/S for forward/backward

        // Calculate movement direction relative to where the player is looking
        Vector3 moveDirection = transform.right * moveX + transform.forward * moveZ;
        float speed = _isCrouching ? crouchSpeed : moveSpeed;

        // Apply movement
        Vector3 velocity = moveDirection.normalized * speed;
        Vector3 currentVelocity = _rb.velocity;
        _rb.velocity = new Vector3(velocity.x, currentVelocity.y, velocity.z);
    }

    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
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
}
