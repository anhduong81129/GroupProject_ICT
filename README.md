# Monster Hunter Survival 2D

A 2D top-down survival game built with Unity, featuring mobile-friendly controls and an endless wave of monsters.
This project was developed to practice Unity 2D game development, AI movement behaviors, and mathematical algorithms for gameplay mechanics.

## How to Play
1.  Open the **Menu** scene and press **Play**.
2.  Use the **on-screen joystick** to move the player.
3.  Avoid the monsters; if they touch you, the game ends, the sword can destroy monsters to protect you.
4.  If the game is too intense, use the **Pause** button to freeze the action.

### 1. Description
**Monster Hunter Survival 2D** is an action-oriented survival game where players must navigate a 2D environment to evade and survive an endless waves of monsters. The game is designed for mobile platforms, utilizing a virtual joystick for movement. Players must use quick reflexes to avoid colliding with monsters while accumulating a high score by surviving or defeating enemies.

---

### 2. Game Mechanics
The gameplay is driven by several interconnected systems:

* **Mobile Movement:** Uses a `FloatingJoystick` to control the player's 2D velocity.
* **Monster AI:** Monsters continuously track the player’s position and move toward it each frame.
* **Monster Spawning:** Monsters spawn at a fixed distance in a random 360-degree radius around the player to keep the action localized.
* **Collision System:** Physical contact with a "Monster" tagged object triggers an immediate Game Over, while contact between the player's sword and a monster destroys the monster and increases the score.
* **Score Tracking:** The score is calculated based on the number of monsters eliminated.
* **Game State Control:** Players can pause the game to freeze time or restart the scene after a loss.

---

### 3. Algorithms Used

### Circular Randomization (Monster Spawning)
**Purpose:**  
To spawn monsters evenly around the player at a fixed distance.

**Algorithm Steps:**
1. Generate a random angle:    
angle = Random.Range(0f, 360f) * Mathf.Deg2Rad  
(random angle between 0° and 360° is generated to represent a direction on a circle)  

2. Convert polar coordinates to Cartesian coordinates:  
x = cos(angle) × spawnDistance  
y = sin(angle) × spawnDistance  
(converts the randomly chosen direction and fixed spawn radius into x and y coordinates so Unity can correctly place monsters around the player)  

3. Add offset to player position:  
spawnPosition = playerPosition + spawnOffset  
(centers the circular spawn position on the player by adding the computed offset to the player’s current position)  

**Result:**  
Monsters spawn uniformly in a circle around the player, preventing unfair instant collisions.  

**Implemented in:** `MonsterSpawner.cs`



### Vector Normalization (Monster AI Movement)

**Purpose:**  
To move monsters toward the player at a constant speed, regardless of distance.

**Algorithm Steps:**
1. Compute direction vector:  
direction = playerPosition - monsterPosition  
(finds the vector pointing from the monster to the player, defining the direction of movement for the chasing AI)  


2. Normalize vector:  
normalizedDirection = direction.normalized  
(converts the direction vector into a unit vector, ensuring monsters move toward the player at a constant speed regardless of distance)  


3. Apply movement:  
monsterPosition += normalizedDirection × moveSpeed × Time.deltaTime  
(moves the monster toward the player each frame at a controlled speed while maintaining frame-rate independent motion)  

**Result:**  
Smooth and consistent chasing behavior independent of frame rate.

**Implemented in:** `MonsterAI.cs`

### Sword orbit Rotation Angle

**Purpose:**  
To rotate the sword continuously around the player as an automatic weapon.

**Algorithm Steps:**
1. Increase rotation angle:  
currentAngle += rotationSpeed × Time.deltaTime  
(increases the sword’s rotation angle each frame, producing smooth continuous spinning independent of frame rate)  

2. Convert to radians:  
angleInRadians = currentAngle × Mathf.Deg2Rad  

3. Compute orbit position:  
x = cos(angle) × orbitRadius  
y = sin(angle) × orbitRadius  
(Sine and cosine functions convert the rotation angle into x and y coordinates, keeping the sword at a fixed circular distance from the player)  

4. Set sword position:  
swordPosition = playerPosition + orbitOffset  
(positions the sword on its circular path around the player by adding the orbit offset to the player’s current position)  

**Result:**  
The sword maintains a circular path around the player and automatically attacks monsters.

**Implemented in:** `SwordController.cs`

### Collision and Score Handling

*Player – Monster Collision**
- Detect collision with object tagged `"Monster"`.
- Stop game time.
- Display Game Over screen.

**Sword – Monster Collision**
- Detect trigger overlap with `"Monster"`.
- Destroy monster object.
- Increase score by 1.

**Implemented in:** `Player.cs` and `SwordController.cs`

---

### 4. Game Design

## Game Architecture
| Component | Responsibility |
|----------|---------------|
| **Player** | Handles joystick input, movement, and Game Over condition |
| **MonsterAI** | Controls enemy chasing behavior |
| **MonsterSpawner** | Manages monster spawn timing and position |
| **SwordController** | Controls sword orbit rotation and monster hits |
| **ScoreUI** | Displays current score |
| **PauseManager** | Handles pause, resume, replay, and menu navigation |
| **MainMenuManager** | Controls main menu scene |

---

## Controls

| Action | Input |
|--------|-------|
| Move Player | Floating Joystick |
| Pause Game | Pause Button |
| Resume | Resume Button |
| Replay | Replay Button |
| Return to Menu | Menu Button |

---

## Engine & Tools

- Unity 2D
- C#
- TextMeshPro
- Floating Joystick UI

---