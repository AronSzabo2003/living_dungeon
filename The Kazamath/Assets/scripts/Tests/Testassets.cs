using NUnit.Framework;
using UnityEngine;

public class GameTests
{
    // 1. TESZT - SpeedBoost mûködik-e
    [Test]
    public void SpeedBoost_Doubles_Player_Stats()
    {
        // Player létrehozása
        GameObject player = new GameObject();
        player.tag = "player";

        Rigidbody2D rb = player.AddComponent<Rigidbody2D>();
        movement move = player.AddComponent<movement>();

        move.speed = 8f;
        move.jumpForce = 12f;

        // SpeedBoost objektum
        GameObject boostObj = new GameObject();
        SpeedBoost boost = boostObj.AddComponent<SpeedBoost>();

        // Trigger collider
        BoxCollider2D trigger = boostObj.AddComponent<BoxCollider2D>();
        trigger.isTrigger = true;

        // Player collider
        player.AddComponent<BoxCollider2D>();

        // Manuálisan meghívjuk a trigger eseményt
        boost.SendMessage("OnTriggerEnter2D", player.GetComponent<Collider2D>());

        // Ellenõrzések
        Assert.AreEqual(16f, move.speed);
        Assert.AreEqual(24f, move.jumpForce);
    }

    // 2. TESZT - Sebzés teleportál-e
    [Test]
    public void Sebzes_Teleports_Player_To_Target()
    {
        // Player
        GameObject player = new GameObject();
        player.tag = "player";
        player.transform.position = Vector3.zero;

        BoxCollider2D playerCol = player.AddComponent<BoxCollider2D>();

        // Célpont
        GameObject target = new GameObject();
        target.transform.position = new Vector3(10f, 5f, 0f);

        // Sebzés objektum
        GameObject sebzesObj = new GameObject();
        Sebzes sebzes = sebzesObj.AddComponent<Sebzes>();

        sebzes.celAllomas = target.transform;

        // Trigger meghívása
        sebzes.SendMessage("OnTriggerEnter2D", playerCol);

        // Ellenõrzés
        Assert.AreEqual(target.transform.position, player.transform.position);
    }

    // 3. TESZT - Goal teleport és speed reset
    [Test]
    public void Goal_Teleports_Player_And_Resets_Stats()
    {
        // Player
        GameObject player = new GameObject();
        player.tag = "player";

        Rigidbody2D rb = player.AddComponent<Rigidbody2D>();
        movement move = player.AddComponent<movement>();

        move.speed = 16f;
        move.jumpForce = 24f;

        // Win text
        GameObject winText = new GameObject();

        // Teleport pont
        GameObject tpPoint = new GameObject();
        tpPoint.transform.position = new Vector3(20f, 3f, 0f);

        // Goal objektum
        GameObject goalObj = new GameObject();
        goal goalScript = goalObj.AddComponent<goal>();

        goalScript.player = player;
        goalScript.winText = winText;
        goalScript.teleportPoint = tpPoint.transform;

        // Meghívjuk közvetlenül a teleport függvényt
        goalObj.SendMessage("TeleportPlayer");

        // Pozíció ellenõrzés
        Assert.AreEqual(tpPoint.transform.position.x, player.transform.position.x);
        Assert.AreEqual(tpPoint.transform.position.y, player.transform.position.y);

        // Stat reset ellenõrzés
        Assert.AreEqual(8f, move.speed);
        Assert.AreEqual(12f, move.jumpForce);
    }
}