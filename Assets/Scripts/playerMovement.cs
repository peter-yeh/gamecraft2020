using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D rb;

    public Animator anim;

    public float jumpForce = 10f;
    public bool doubleJump = true;
    public Transform feet;
    public LayerMask groundLayers;

    float mx;

    private void Update() {
        mx = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded()) {
            Jump();
        } else if (Input.GetButtonDown("Jump") && doubleJump) {
            doubleJump = false;
            Jump();
        }

        if (Mathf.Abs(mx) > 0.05f) {
            anim.SetBool("isRunning", true);
        } else {
            anim.SetBool("isRunning", false);
        }

        if (mx > 0f) { // face right 
            transform.localScale = new Vector3(1f, 1f, 1f);
        } else if (mx < 0f) { // face left
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        anim.SetBool("isGrounded", IsGrounded());
    }

    private void FixedUpdate() {
        Vector2 movement = new Vector2(mx * movementSpeed, rb.velocity.y);

        rb.velocity = movement;
    }

    void Jump() {
        Vector2 movement = new Vector2(rb.velocity.x, jumpForce);

        rb.velocity = movement;
    }

    public bool IsGrounded() {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);

        if (groundCheck != null) {
            doubleJump = true;
            return true;
        }

        return false;
    }
}
