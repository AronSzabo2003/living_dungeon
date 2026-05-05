using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 2f;
    private bool movingRight = true;

    public Transform wallCheck;  // Az üres objektum az ellenség elején
    public float wallDetectionDistance = 0.5f; // Milyen messze legyen a fal, hogy megforduljon
    public LayerMask whatIsWall; // Beállíthatod, hogy csak a Tilemap-et (falat) nézze

    void Update()
    {
        // Folyamatos mozgás elõre
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        // Sugarat lövünk elõre, hogy látjuk-e a falat
        RaycastHit2D wallInfo = Physics2D.Raycast(wallCheck.position, transform.right, wallDetectionDistance, whatIsWall);

        // Ha a sugár falat talál, megfordulunk
        if (wallInfo.collider != null)
        {
            Flip();
        }
    }

    void Flip()
    {
        if (movingRight)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            movingRight = false;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            movingRight = true;
        }
    }

    // Segítség a Scene ablakban, hogy lásd a sugarat (opcionális)
    private void OnDrawGizmos()
    {
        if (wallCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(wallCheck.position, wallCheck.position + transform.right * wallDetectionDistance);
        }
    }
}