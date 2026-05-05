using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    // Itt nem OnCollision, hanem OnTrigger kell, mert bepipáltuk az "Is Trigger"-t!
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Csak akkor történik valami, ha a Player lép bele
        if (other.CompareTag("player"))
        {
            // 1. Lekérjük a Player mozgás szkriptjét. 
            // FIGYELEM: A "PlayerMovement" szót cseréld ki a te szkripted PONTOS nevére!
            movement playerScript = other.GetComponent<movement>();

            // Ha megtaláltuk a szkriptet a Playeren
            if (playerScript != null)
            {
                // 2. Megduplázzuk az értékeket
                playerScript.speed *= 2f;
                playerScript.jumpForce *= 2f;

                // Opcionális: Kiírjuk a konzolba, hogy lássuk, mûködik-e
                Debug.Log("Szupersebesség aktiválva!");

                // 3. Eltüntetjük (megsemmisítjük) magát a tárgyat, hiszen felvettük
                Destroy(gameObject);
            }
        }
    }
}