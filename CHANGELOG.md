# Changelog

Ebben a fájlban rögzítjük a **Living Dungeon** (2D Platformer) projekt frissítéseit és módosításait.
A formátum a [Keep a Changelog](https://keepachangelog.com/) ajánlásait követi.

## [0.1.0] - 2026-04-15
### Hozzáadva (Mechanikák és Rendszerek)
- **2D Karakter Irányítás (`movement.cs`):** - Vízszintes mozgás és ugrás implementálása `Rigidbody2D` segítségével.
  - Talajérzékelés (Ground check) beállítása, hogy a játékos csak a földről tudjon ugrani.
  - Sprite forgatása (FlipX) a haladási iránynak megfelelően.
- **Ellenség AI (`EnemyPatrol.cs`):** - Járőröző ellenség, amely Raycast segítségével érzékeli a falakat maga előtt, és automatikusan megfordul.
## [0.2.0] - 2026-04-30
- **Interakciós Rendszerek:**
  - `NPCInteract.cs`: 'E' gomb megnyomására felugró/eltűnő párbeszédablak.
  - `LetraLefele.cs`: Létra használata, amivel a karakter egy alsóbb szintre teleportálható ('E' gomb).
- **Akadályok és Halál:**
  - `DeathZoneHandler.cs`: Szakadékok és halálzónák, amikbe beleesve a pálya újratöltődik.
  - `Killing.cs`: Ellenséggel vagy csapdával való fizikai érintkezés esetén a szint azonnali újratöltése.
## [0.3.0] - 2026-05-03
- **Power-upok:**
  - `SpeedBoost.cs` és `SpeedBoost_2.cs`: Felvehető tárgyak, amik 2x-es vagy 1.2x-es szorzót adnak a sebességre és az ugrás erejére, majd eltűnnek.
- **Győzelmi Feltételek:**
  - `WinCondition.cs` és `goal.cs`: Célzónák, ahol a megfelelő gombok ('E' vagy 'Enter') lenyomására felugrik a győzelmi felirat, az idő megáll, és a karakter paraméterei módosulnak.
- **Fizika:** `csuszos` PhysicsMaterial2D hozzáadása 0 súrlódással a csúszós felületekhez.