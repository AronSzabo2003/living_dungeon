using UnityEngine;

public class LetraLefele : MonoBehaviour
{
    public Transform alsoPont; // Ide húzzuk majd a létra alját

    private bool isAtLadder = false;
    private GameObject playerObject; // Itt jegyezzük meg, hogy ki lépett a létrára

    void Update()
    {
        // Ha a játékos a létránál van ÉS lenyomja az 'S' betût
        if (isAtLadder && Input.GetKeyDown(KeyCode.E))
        {
            // Biztonsági ellenõrzés, hogy tényleg megvan-e a játékos
            if (playerObject != null)
            {
                // Teleportálás lefelé
                playerObject.transform.position = alsoPont.position;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Ellenõrizd, hogy a Tag kis vagy nagy betûvel van-e nálad! (pl. "Player" vagy "player")
        if (other.CompareTag("player"))
        {
            isAtLadder = true;
            playerObject = other.gameObject; // Eltároljuk a játékos objektumát
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            isAtLadder = false;
            playerObject = null; // Ha elsétál, elfelejtjük
        }
    }
}