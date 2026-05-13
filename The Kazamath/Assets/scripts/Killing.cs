using UnityEngine;
using UnityEngine.SceneManagement; // Ez kell a pálya újratöltéséhez!

public class Killing : MonoBehaviour
{
    // Ez a függvény automatikusan lefut, ha az objektum valaminek nekiütközik
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Megnézzük, hogy az, aminek nekiütköztünk, az a "Player" címkével rendelkezik-e
        if (collision.gameObject.CompareTag("player"))
        {
            // Ha igen, újratöltjük az aktuális pályát
            RestartLevel();
        }
    }

    // Pálya újratöltõ függvény
    private void RestartLevel()
    {
        // Lekérjük a jelenlegi pálya nevét/számát, és újra betöltjük azt
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        movement playerScript = GetComponent<movement>();
        playerScript.speed = 4;
        playerScript.jumpForce = 6;
    }
}