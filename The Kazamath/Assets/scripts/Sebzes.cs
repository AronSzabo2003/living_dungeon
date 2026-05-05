using UnityEngine;

public class Sebzes : MonoBehaviour
{
    // Ide fogjuk behúzni azt a pontot, ahova a játékost küldeni akarjuk
    public Transform celAllomas;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Megnézzük, hogy a Játékos lépett-e bele a teleportba
        if (other.CompareTag("player"))
        {
            // A játékos pozícióját egyenlõvé tesszük a célállomás pozíciójával
            other.transform.position = celAllomas.position;
        }
    }
}