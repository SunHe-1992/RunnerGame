using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator playerAnim;
    public Rigidbody playerRigid;
    public float moveSpeed = 5f;
    public float rotationSpeed = 180f;

    void Update()
    {
        // Check for movement input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 movement = new Vector3(horizontal, 0f, vertical).normalized;

        // Check if there is any movement input
        if (movement.magnitude >= 0.1f)
        {
            // Calculate and apply the rotation
            float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref rotationSpeed, 0.1f);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // Calculate and apply the movement
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            playerRigid.MovePosition(transform.position + moveDirection * moveSpeed * Time.deltaTime);

            // Set "Run" trigger in the animator
            playerAnim.SetBool("run", true);
        }
        else
        {
            // No movement input, set "Run" trigger to false and play "Idle" animation
            playerAnim.SetBool("idle", true);
        }
    }
}
