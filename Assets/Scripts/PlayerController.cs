using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

    float moveSpeed = 6;
    float xInput;
    float zInput;

    void Update()
    {
        // Rotation
        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X"));

        // Movement
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");
        Vector3 moveVelocity = new Vector3(xInput, 0, zInput) * moveSpeed * Time.deltaTime;
        transform.position += transform.rotation * moveVelocity;

        // Animation
        if (moveVelocity == Vector3.zero)
            animator.SetBool("Is Running", false);
        else
            animator.SetBool("Is Running", true);
    }
}
