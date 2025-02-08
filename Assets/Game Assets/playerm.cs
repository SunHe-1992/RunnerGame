using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator playerAnim;
    public Rigidbody playerRigid;
    public Transform playerVisual;
    public float moveSpeed = 3f;
    public float lrSpeed = 9f;
    public float rotationSpeed = 180f;
    public float jumpForce = 10f;
    public float crouchScale = 0.5f;
    public Transform groundCheck;
    public LayerMask groundMask;
    public CapsuleCollider capsuleCollider;

    private bool isGrounded;

    public void MoveForward()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        playerAnim.SetTrigger("run");
    }

    public void Jump()
    {
        if (isGrounded)
        {
            playerRigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            playerAnim.SetTrigger("jump");
        }
    }

    public void Crouch()
    {
        playerAnim.SetTrigger("slide");
        capsuleCollider.height = 0.8258972f;
        capsuleCollider.center = new Vector3(0.006896973f, -0.423111f, 0.1062469f);
    }

    public void ResetCrouch()
    {
        capsuleCollider.height = 1.916809f;
        capsuleCollider.center = new Vector3(0.006896973f, 0.03842163f, 0.1062469f);
    }

    public void MoveLeft()
    {
        transform.Translate(Vector3.left * Time.deltaTime * lrSpeed);
    }

    public void MoveRight()
    {
        transform.Translate(Vector3.right * Time.deltaTime * lrSpeed);
    }

    private void Update()
    {
        // Keep moving forward continuously
        Vector3 moveDirection = transform.forward * moveSpeed;
        playerRigid.MovePosition(transform.position + moveDirection * Time.deltaTime);

        // Check for jump input
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            Jump();
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            playerAnim.SetTrigger("run");
        }

        // Check for crouch input
        if (Input.GetKeyDown(KeyCode.S))
        {
            Crouch();
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            ResetCrouch();
            playerAnim.SetTrigger("run");
        }

        // Check for flip input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAnim.SetTrigger("flip");
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            playerAnim.SetTrigger("run");
        }

        // Check for left/right movement input
        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }

        if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }
    }

    private void FixedUpdate()
    {
        // Check if the player is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundMask);
    }
}
