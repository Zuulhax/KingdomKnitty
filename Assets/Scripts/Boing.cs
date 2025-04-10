using UnityEngine;
using UnityEngine.InputSystem;

public class Boing : MonoBehaviour
{
    private PlayerInput playerInput;
    public float jumpForce = 7f;
    public float groundCheckDistance = -6f;
    public LayerMask groundLayer;

    private Rigidbody rb;
    private bool isGrounded;
    private InputAction jump;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInput.currentActionMap.Enable();

        if (rb == null)
        {
            Debug.LogError("Rigidbody not found on player object!");
            enabled = false;
            return;
        }

        jump = playerInput.currentActionMap.FindAction("Jump");
    }

    void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);

        // Check for jump input and only jump if grounded
        if (jump.triggered && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false; // Prevent immediate double jump
    }
}
