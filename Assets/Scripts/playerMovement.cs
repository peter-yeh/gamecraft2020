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

    public GameObject bombExplosion; // Collision with bomb
    public GameObject foodExplosion; // Collision with ingredient

    float mx;

    private void Update()
    {
        mx = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }
        else if (Input.GetButtonDown("Jump") && doubleJump)
        {
            doubleJump = false;
            Jump();
        }

        if (Mathf.Abs(mx) > 0.05f)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if (mx > 0f)
        { // face right 
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (mx < 0f)
        { // face left
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        anim.SetBool("isGrounded", IsGrounded());
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(mx * movementSpeed, rb.velocity.y);

        rb.velocity = movement;
    }

    void Jump()
    {
        Vector2 movement = new Vector2(rb.velocity.x, jumpForce);

        rb.velocity = movement;
    }

    public bool IsGrounded()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);

        if (groundCheck != null)
        {
            doubleJump = true;
            return true;
        }

        return false;
    }


    private int[] ingredientBasket = new int[5];
    private int health = 3;

    // Collision with ingredients and bombs
    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(col.gameObject); // Destroy the ingredient or bomb 

        // Explosion effect
        switch (col.tag)
        {
            case "Bomb":
                health--;
                Instantiate(bombExplosion, transform.position, transform.rotation);
                if (health <= 0)
                {
                    // Game over
                    Debug.Log("Health less than or equals to 0");
                }
                Debug.Log("Collision with bomb \n Health left: " + health);

                break;

            case "Food1": // Orange, Rice, Bun
                ingredientBasket[0]++;
                Instantiate(foodExplosion, transform.position, transform.rotation);
                Debug.Log("Collected food1, it is now: " + ingredientBasket[0]);
                break;

            case "Food2": // Chocolate, Seaweed, Lettuce
                ingredientBasket[1]++;
                Instantiate(foodExplosion, transform.position, transform.rotation);
                Debug.Log("Collected food2, it is now: " + ingredientBasket[1]);
                break;

            case "Food3": // Milk, Cucumber, Meat
                ingredientBasket[2]++;
                Instantiate(foodExplosion, transform.position, transform.rotation);
                Debug.Log("Collected food3, it is now: " + ingredientBasket[2]);
                break;

            case "Food4": // Ice, Salmon, Ketchup
                ingredientBasket[3]++;
                Instantiate(foodExplosion, transform.position, transform.rotation);
                Debug.Log("Collected food4, it is now: " + ingredientBasket[3]);
                break;

            case "Food5": // Strawberry, Avocado, Cheese
                ingredientBasket[4]++;
                Instantiate(foodExplosion, transform.position, transform.rotation);
                Debug.Log("Collected food5, it is now: " + ingredientBasket[4]);
                break;

            default:
                Debug.LogError("Collided with something not bomb or food");
                break;
        }
    }
}
