# 🧱 Boundary Test 2 — BT-002: PlayerController Zone Limits

**Goal:**  
Confirm that the PlayerController script correctly prevents the player from moving outside the allowed rink area.

**Rationale:**  
This verifies that position clamping or movement boundaries inside the PlayerController work as intended — the player should stop at the edge and not slide out of bounds.

**Expected Result:**  
When automatic movement pushes the player toward the rink edges, their position remains within the legal min/max X and Y values set in PlayerController.

**Outcome:**  
✅ **PASS** — Player movement correctly stopped at rink edges with no boundary violations detected.

