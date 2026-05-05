using UnityEngine;
using TMPro;

public class goal : MonoBehaviour
{
    public GameObject winText;       // A Canvas-on lévõ szöveged
    public Transform teleportPoint;  // Az üres objektum, ahova ugrani kell
    public GameObject player;        // Maga a Player objektum

    private bool isAtGoal = false;   // Belsõ változó: elértük-e a célt?

    void Update()
    {
        // Ha már elértük a célt ÉS megnyomjuk az Entert
        if (isAtGoal && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
        {
            TeleportPlayer();
        }
    }

    // Ez fut le, ha a karakter belelép a "Trigger"-be
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player")) // Ellenõrizd, hogy a Playeren nagy P-vel van-e a Tag!
        {
            winText.SetActive(true);
            isAtGoal = true;
        }
    }
    void TeleportPlayer()
    {
        // 1. Megállítjuk a fizikát
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
            rb.Sleep(); // Elaltatjuk a fizikát egy pillanatra
        }

        // 2. Teleportálás (Z kényszerítve 0-ra)
        player.transform.position = new Vector3(teleportPoint.position.x, teleportPoint.position.y, 0f);

        // Kényszerítjük a Unity-t, hogy azonnal regisztrálja az új helyet
        Physics2D.SyncTransforms();

        // 3. Felébresztjük a fizikát
        if (rb != null) rb.WakeUp();

        winText.SetActive(false);
        isAtGoal = false;

        movement playerScript = player.GetComponent<movement>();

        // Biztonsági ellenõrzés, hogy tényleg megvan-e a szkript
        if (playerScript != null)
        {
            // Elfelezzük az értékeket osztással (/=)
            playerScript.speed /= 2f;
            playerScript.jumpForce /= 2f;
        }
    }
}