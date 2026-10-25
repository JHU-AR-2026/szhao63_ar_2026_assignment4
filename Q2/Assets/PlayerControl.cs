
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public Material poweredPlayerMaterial;

    private bool isPoweredUp = false;

    public GameObject powerUpText;
    public GameObject youWinText;

    private InputAction moveAction;
    private InputAction jumpAction;
    private Rigidbody rb;

    public float speed = 5f;
    public float powerUpSpeedMultiplier = 4.0f;
    public float jumpForce = 5f;

    private bool isGrounded = false;
    private bool jumpQueued = false;

    // Called before the first Update
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");

        rb = GetComponent<Rigidbody>();
    }

    // Called once per frame
    void Update()
    {
        if (jumpAction.WasPressedThisFrame() && isGrounded)
        {
            jumpQueued = true;
        }
    }

    // Called at a fixed interval for physics
    private void FixedUpdate()
    {
        // Jump
        if (jumpQueued)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            isGrounded = false;
            jumpQueued = false;
        }

        // Movement
        Vector2 moveValue = moveAction.ReadValue<Vector2>();

        Vector3 movement = new Vector3(
            -moveValue.x,
            0f,
            -moveValue.y
        );

        rb.AddForce(movement * speed, ForceMode.Force);
    }

    // Detect collisions with the floor
    private void OnCollisionEnter(Collision collision)
    {
        // This function is called only when the player collides with another object. 
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("SpecialWall") && isPoweredUp)
        {
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Goal"))
        {
            youWinText.SetActive(true);
            powerUpText.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            other.gameObject.SetActive(false);

            GameManager gameManager =
                FindFirstObjectByType<GameManager>();

            gameManager.CollectItem();
        }

        if (other.gameObject.CompareTag("PowerUp"))
        {
            speed *= powerUpSpeedMultiplier;

            GetComponent<Renderer>().material = poweredPlayerMaterial;

            powerUpText.SetActive(true);

            other.gameObject.SetActive(false);

            isPoweredUp = true;
        }
        
    }

}
