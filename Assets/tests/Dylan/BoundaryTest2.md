# Boundary Test 2 — BT-002: Player Goal Collision

**Goal:**  
Ensure that the player cannot enter or pass through the goal area.

**Rationale:**  
This verifies that PlayerController correctly prevents the player from moving into restricted zones like the goal crease, using collider interactions or position limits.

**Expected Result:**  
When the player moves or is automatically pushed toward either goal, the player stops at the goal boundary and cannot overlap or clip inside it.

**Outcome:**  
**PASS** — Player movement was blocked by the goal colliders and did not enter the restricted goal area.


