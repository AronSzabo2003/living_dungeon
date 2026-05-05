using UnityEngine;

public class WinCondition : MonoBehaviour
{
    // Ide húzzuk be a kikapcsolt VictoryScreen panelt
    public GameObject victoryScreen;

    // Figyeljük, hogy a játékos ott van-e
    private bool isPlayerAtGoal = false;

    // Számoljuk, hányszor nyomta meg az E betût
    private int eKeyPressCount = 0;

    void Update()
    {
        // Ha a játékos ott van a célnál ÉS megnyomja az 'E' gombot
        if (isPlayerAtGoal && Input.GetKeyDown(KeyCode.E))
        {
            eKeyPressCount++; // Hozzáadunk egyet a számlálóhoz

            // Ha elérte a kettõt, nyert!
            if (eKeyPressCount >= 2)
            {
                // Bekapcsoljuk a gyõzelmi képernyõt
                victoryScreen.SetActive(true);

                // Megállítjuk a játékot (az idõt)
                Time.timeScale = 0f;
            }
        }
    }

    // Amikor a játékos BELÉP a cél zónájába
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player")) // Ellenõrizd a Tag kis/nagy betûjét!
        {
            isPlayerAtGoal = true;
            eKeyPressCount = 0; // Nullázzuk a számlálót, amikor megérkezik
        }
    }

    // Amikor a játékos KILÉP a cél zónájából (elsétál)
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            isPlayerAtGoal = false;
            eKeyPressCount = 0; // Nullázzuk, ha elsétált a céltól
        }
    }
}