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
        // Teleportálás
        player.transform.position = new Vector3(teleportPoint.position.x, teleportPoint.position.y, 0f);

        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero; // Sebesség nullázása
            rb.angularVelocity = 0f;          // Forgás nullázása
        }

        winText.SetActive(false);
        isAtGoal = false;
    }
}