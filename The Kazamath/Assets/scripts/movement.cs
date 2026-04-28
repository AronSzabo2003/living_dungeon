using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed = 8f;        // Mozgási sebesség
    public float jumpForce = 12f;   // Ugrás ereje

    private Rigidbody2D rb;
    private SpriteRenderer sprite;  // Ez kell a megforduláshoz
    private bool isGrounded;        // Figyeli, hogy a földön vagyunk-e

    void Start()
    {
        // Megkeressük a komponenseket
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // 1. Vízszintes mozgás
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);

        // 2. Megfordulás (Flip) - Ez nem bántja a Scale-t!
        if (moveInput > 0)
        {
            sprite.flipX = false; // Jobbra néz
        }
        else if (moveInput < 0)
        {
            sprite.flipX = true;  // Balra néz
        }

        // 3. Ugrás
        // Itt figyeli a Space-t ÉS hogy a földön vagy-e
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    // Ütközés figyelése a talajhoz
    private void OnCollisionStay2D(Collision2D collision)
    {
        // Végigmegyünk az összes ponton, ahol hozzáérünk valamihez
        foreach (ContactPoint2D contact in collision.contacts)
        {
            // Ha az ütközési pont iránya felfelé mutat (tehát alulról érintkezünk)
            if (contact.normal.y > 0.5f)
            {
                isGrounded = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Ha elhagyjuk a talajt (ugrás vagy leesés)
        isGrounded = false;
    }
}