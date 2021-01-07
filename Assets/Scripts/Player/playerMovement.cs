using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    //public GameObject foodExplosion; // Collision with ingredient

    public GameObject audioManager;

    protected float mx;

    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private int health = 3;

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

    [Space(20)]
    [Header("Required to be filled up for each level")]
    [SerializeField] private GameObject[] recipesObject;
    [SerializeField] private GameObject timeUpMenu;
    [SerializeField] private GameObject timeUpText;
    private WaitForSeconds wait = new WaitForSeconds(0.5f);
    [Space(10)]

    private int[] ingredientBasket = new int[5];
    public void TimeUp()
    {

        SceneManager.LoadScene(7);
        Storage.GetStorage().ingredientBasket = ingredientBasket;


        //timeUpMenu.SetActive(true);
        //int level = Storage.GetStorage().GetCurrentLevel();
        //List<int> recipeUnlocked = LevelUnlocked.Unlock(ingredientBasket, level);

        //Debug.Log("The ingredient basket is: " + String.Join(", ", ingredientBasket));
        //Debug.Log("The recipe unlocked is: " + String.Join(", ", recipeUnlocked));

        //foreach (int i in recipeUnlocked)
        //{
        //    recipesObject[i].SetActive(true);
        //    if (i < 3)
        //    {
        //        Storage.GetStorage().SetLevelUnlocked(2);
        //    }
        //    if (i >= 3)
        //    {
        //        Storage.GetStorage().SetLevelUnlocked(3);
        //    }


        //}

        //if (recipeUnlocked.Count == 0)
        //{
        //    // help meeee idk how to use the text pro...
        //    timeUpText.GetComponent<TextMeshProUGUI>().text += "\n Oh no, no new recipes unlocked";
        //}
        //else
        //{
        //    timeUpText.GetComponent<TextMeshProUGUI>().text += "Yay! You unlocked " + recipeUnlocked.Count + " new recipes";
        //}


    }

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
                break;

            case "Fire":
                audioManager.GetComponent<SoundEffects>().PlaySound("Explosion");
                health--;
                GameObject fireHurt = Instantiate(bombExplosion, transform.position, transform.rotation);
                Destroy(fireHurt, 2f); // 2s delay before destroying clone
                if (health <= 0)
                {
                    // Game over
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

            case "Portal":
                Debug.Log("Teleporting");
                break;

            default:
                Destroy(col.gameObject);
                Debug.LogError("Collided with something not bomb or food");
                break;
        }
    }
}
