using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    bool alive = true;
    public float speed = 5;
    [SerializeField] Rigidbody rb;

    public float horizontalInput;
    [SerializeField] float horizontalMultiplier = 2;
    public float speedIncreasePerPoint = 0.1f;
    [SerializeField] float jumpForce = 400f;
    [SerializeField] LayerMask groundMask;
    
    // Define boundaries for the player's movement
    public float minX = -5f;
    public float maxX = 5f;
    float maxJumpHeight = 4.0f; // Set your maximum jump height here

    private void FixedUpdate()
    {
        if (!alive) return;

        // Calculate movement in the forward direction
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        
        // Calculate movement in the horizontal direction
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;

        // Calculate the new position
        Vector3 newPosition = rb.position + forwardMove + horizontalMove;

        // Clamp the new horizontal position to stay within the defined bounds
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

        // Move the Rigidbody to the new position
        rb.MovePosition(newPosition);
    }

    private void Update()
    {
        // Get horizontal input from user
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        // Check if the player falls below a certain height
        if (transform.position.y < -5)
        {
            Die();
        }
    }

    public void Die()
    {
        alive = false;
        // Restart game
        Invoke("Restart", 1);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Jump()
    {
        // Check whether we are grounded
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);
        
        // If we are grounded and not already jumping
        if (isGrounded && rb.velocity.y <= 0)
        {
            // Calculate the jump force based on maximum jump height
            float jumpForceToApply = Mathf.Sqrt(2 * Physics.gravity.magnitude * maxJumpHeight);
            
            // Apply the jump force
            rb.AddForce(Vector3.up * jumpForceToApply, ForceMode.VelocityChange);
        }
    }
}
