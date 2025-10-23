# Boundary Test 1 — BT-001: Player Stays Inside Rink

**Goal:**  
Ensure the player cannot leave the play area or clip through rink walls.

**Rationale:**  
Confirms that wall colliders and the player’s rigidbody correctly enforce game boundaries.

**Expected Result:**  
When automatically nudged toward all four edges (left, right, top, bottom), the player always remains within the legal rink area.

**Outcome:**  
**PASS** — Player position stayed inside bounds on all sides.

