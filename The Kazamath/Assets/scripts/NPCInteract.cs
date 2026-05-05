using UnityEngine;

public class NPCInteract : MonoBehaviour
{
    // Ide húzzuk be a kikapcsolt szöveg objektumot
    public GameObject dialogueBox;

    // Ez figyeli, hogy a játékos elég közel van-e
    private bool isPlayerInRange = false;

    void Update()
    {
        // Ha a játékos a zónában van, ÉS lenyomja az 'E' betût
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            // Bekapcsoljuk a szöveget, ha ki volt kapcsolva, 
            // vagy kikapcsoljuk, ha be volt (így be/ki lehet kapcsolgatni)
            bool isCurrentlyActive = dialogueBox.activeSelf;
            dialogueBox.SetActive(!isCurrentlyActive);
        }
    }

    // Amikor a játékos belép a karakter területére (a Triggerbe)
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            isPlayerInRange = true;
        }
    }

    // Amikor a játékos elsétál a karaktertõl
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            isPlayerInRange = false;
            // Automatikusan eltüntetjük a szöveget, ha elsétál
            dialogueBox.SetActive(false);
        }
    }
}