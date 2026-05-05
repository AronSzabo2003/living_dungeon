using UnityEngine;
using UnityEngine.SceneManagement; // Ez kell a pálya újratöltéséhez!

public class DeathZoneHandler : MonoBehaviour
{
    // Amikor valami BELEESIK a Trigger-be
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Csak akkor csinálunk valamit, ha a Player esett le
        if (other.CompareTag("player"))
        {
            // Lekérjük a jelenlegi pálya nevét, és újra betöltjük azt
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}