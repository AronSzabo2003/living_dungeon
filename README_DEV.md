# Living Dungeon - Fejlesztői Dokumentáció 


 **Csak játszani szeretnél?** Akkor olvasd el a játékosoknak szóló [Használati útmutatót (README_USER.md)](README_USER.md)!*

A **Living Dungeon** (The Kazamath) egy Unity-ben készülő 2D-s platformer / kalandjáték. A projekt a 2D-s fizikára, ügyességi feladatokra és logikai/interakciós elemekre épít.

## Technológiai Stack
- **Játékmotor:** Unity 3D (2D-s környezetben használva)
- **Programozási nyelv:** C#
- **Fizika:** Unity 2D Physics (`Rigidbody2D`, `Collider2D`, `RaycastHit2D`)

## Főbb Rendszerek a kódban
A `Scripts` mappában található legfontosabb C# scriptek és funkcióik:
- **`movement.cs`:** A játékos alapvető mozgásáért felel. `Input.GetAxisRaw`-t használ a precíz irányításhoz, és ütközésvizsgálattal (`OnCollisionStay2D`) ellenőrzi a talajt az ugráshoz.
- **`EnemyPatrol.cs`:** Egyszerű AI, amely folyamatosan halad, és egy előre lőtt sugárral (Raycast) detektálja a LayerMask alapján kijelölt falakat, majd megfordul.
- **`LetraLefele.cs` & `NPCInteract.cs`:** Zóna-alapú interakciók (`OnTriggerEnter2D`), amik gombnyomásra reagálva manipulálják a játékost vagy a UI elemeket.
- **`WinCondition.cs` / `goal.cs`:** A pálya befejezését kezelik. Képesek leállítani a játékidejét (`Time.timeScale = 0f`), vagy elaltatni a fizikát a teleportálás idejére.


## Architektúra és Mappastruktúra
A projekt tartalmazza a standard Unity könyvtárakat (`Packages`, `ProjectSettings`). A saját tartalom a **`The Kazamath`** mappába lett izolálva, hogy elkülönüljön az esetleges harmadik féltől származó assetektől.

/living_dungeon
 ├── Packages/              # Unity csomagkezelő mappája
 ├── ProjectSettings/       # Unity projekt konfigurációk
 ├── The Kazamath/          # A JÁTÉK FŐ MAPPÁJA
 │    └── Assets/
 │         ├── Scenes/      # Pályák (pl. SampleScene.unity)
 │         ├── Scripts/     # C# Kódok
 │         ├── Materials/   # Anyagok és Shaderek
 │         └── Prefabs/     # Újrafelhasználható játékelemek


## Indítás a Unity Editorban
Ha fejleszteni vagy tesztelni szeretnéd a projektet:

1. **Repó klónozása:**
    bash
   git clone [https://github.com/AronSzabo2003/living_dungeon.git](https://github.com/AronSzabo2003/living_dungeon.git)