using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcyPlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public float icySpeed;
    public Rigidbody2D rb;

    public Animator anim;

    public float jumpForce = 10f;
    public bool doubleJump = true;
    public Transform feet;
    public LayerMask groundLayers;

    public GameObject bombExplosion; // Collision with bomb
    //public GameObject foodExplosion; // Collision with ingredient

    public GameObject audioManager;

    float mx;

    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private int health = 3;

    public float knockbackAmount;

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
        bool grounded = IsGrounded();

        if (grounded)
        {
            Vector2 Movement = new Vector2(mx, 0);
            rb.AddForce(Movement * icySpeed);

        } else
        {
            Vector2 movement = new Vector2(mx * movementSpeed, rb.velocity.y);

            rb.velocity = movement;
        }
    }

    void Jump()
    {
        audioManager.GetComponent<SoundEffects>().PlaySound("Jump");
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

    // Collision with ingredients and bombs and fire trap
    void OnTriggerEnter2D(Collider2D col)
    {
        // Explosion effect
        switch (col.tag)
        {
            case "Bomb":
                Destroy(col.gameObject); // Destroy the bomb 
                audioManager.GetComponent<SoundEffects>().PlaySound("Explosion");
                health--;
                GameObject explosion = Instantiate(bombExplosion, transform.position, transform.rotation);
                Destroy(explosion, 2f); // 2s delay before destroying clone
                if (health <= 0)
                {
                    // Game over
                    audioManager.GetComponent<SoundEffects>().PlaySound("GameOver");
                    Debug.Log("Health less than or equals to 0");


                }
                playerHealth.decreaseHealth();
                Debug.Log("Collision with bomb \n Health left: " + health);

                Debug.Log("Ingredient basket contains: " + ingredientBasket.ToString() +
                    "\nUnlocks: " + LevelUnlocked.Unlock(ingredientBasket, 1).ToString());
                break;

            case "Fire":
                //audioManager.GetComponent<SoundEffects>().PlaySound("Explosion");
                health--;
                //Vector2 direction = (this.transform.position - col.transform.position).normalized;
                //transform.position = Vector2.MoveTowards(transform.position, col.transform.position, -knockbackAmount * Time.deltaTime);
                //rb.AddForce(direction * knockbackAmount, ForceMode2D.Force);
                //this.transform.Translate(direction * knockbackAmount);
                //GameObject explosion = Instantiate(bombExplosion, transform.position, transform.rotation);
                //Destroy(explosion, 2f); // 2s delay before destroying clone
                if (health <= 0)
                {
                    // Game over
                    audioManager.GetComponent<SoundEffects>().PlaySound("GameOver");
                    Debug.Log("Health less than or equals to 0");
                }
                playerHealth.decreaseHealth();
                Debug.Log("Touched Fire \n Health left: " + health);

                break;

            case "Food1": // Orange, Rice, Bun
                Destroy(col.gameObject); // Destroy the ingredient
                audioManager.GetComponent<SoundEffects>().PlaySound("Ingredient");
                ingredientBasket[0]++;
                //Instantiate(foodExplosion, transform.position, transform.rotation);
                //Debug.Log("Collected food1, it is now: " + ingredientBasket[0]);
                break;

            case "Food2": // Chocolate, Seaweed, Lettuce
                Destroy(col.gameObject); // Destroy the ingredient
                audioManager.GetComponent<SoundEffects>().PlaySound("Ingredient");
                ingredientBasket[1]++;
                //Instantiate(foodExplosion, transform.position, transform.rotation);
                //Debug.Log("Collected food2, it is now: " + ingredientBasket[1]);
                break;

            case "Food3": // Milk, Cucumber, Meat
                Destroy(col.gameObject); // Destroy the ingredient
                audioManager.GetComponent<SoundEffects>().PlaySound("Ingredient");
                ingredientBasket[2]++;
                //Instantiate(foodExplosion, transform.position, transform.rotation);
                //Debug.Log("Collected food3, it is now: " + ingredientBasket[2]);
                break;

            case "Food4": // Ice, Salmon, Ketchup
                Destroy(col.gameObject); // Destroy the ingredient
                audioManager.GetComponent<SoundEffects>().PlaySound("Ingredient");
                ingredientBasket[3]++;
                //Instantiate(foodExplosion, transform.position, transform.rotation);
                //Debug.Log("Collected food4, it is now: " + ingredientBasket[3]);
                break;

            case "Food5": // Strawberry, Avocado, Cheese
                Destroy(col.gameObject); // Destroy the ingredient
                audioManager.GetComponent<SoundEffects>().PlaySound("Ingredient");
                ingredientBasket[4]++;
                //Instantiate(foodExplosion, transform.position, transform.rotation);
                //Debug.Log("Collected food5, it is now: " + ingredientBasket[4]);
                break;

            default:
                Destroy(col.gameObject);
                Debug.LogError("Collided with something not bomb or food");
                break;
        }
    }
}
