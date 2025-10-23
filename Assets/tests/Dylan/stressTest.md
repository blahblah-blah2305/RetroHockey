# Stress Test — ST-001: PlayerController Speed Stress with another colliding player

**Goal:**  
Gradually increase the player’s movement speed until the system or boundaries fail or problems arise with the other player.

**Rationale:**  
This stress test pushes the PlayerController to extreme values to find when the physics or boundary logic break down.

**Expected Result:**  
Player accelerates repeatedly across the rink.  
If they clip through walls, goals, or behave abnormally then we will classify it as a failure point.

**Test Setup:**  
- Used the `PlayerStressTest` script in Unity.  
- Player starts at one end of the rink and loops toward the goal, increasing speed every pass.  
- Test runs automatically on Play

**Result:**  
Video Below in Player_test.mov

The player progressively speeds up until physics behavior becomes unstable and
