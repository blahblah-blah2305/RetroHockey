# Boundary Test Documentation: BT-001 Zone Edge Integrity

**Goal:** Verify that the AI player correctly reverses and clamps its position at the defined zone boundaries (`MaxX` and `MinY`), preventing any zone exit.

**System Tested:** AI Movement Logic, Clamping Logic, Rigidbody2D Physics

| Parameter | Value |

| Test Subject | LeftWing|
| MaxX Boundary | 4.0 |
| MinY Boundary | -4.0 |

---

## Test Procedure

| Step | Procedure | Expected Result | Pass/Fail Criteria |
| 1. Setup (High Speed) | In the Inspector, set AI's Maxspeed to 20 and Acceleration** to 50. | AI should be highly responsive for the test. | *Setup Complete* |
| **2. Test MaxX Boundary** | Pause the game. Manually set the AI's position to (MaxX - 0.1). Force its `targetDirection.x` to **+1**. Resume the game. | The AI's position is immediately clamped to 4.0. The internal `targetDirection.x` flips to **-1**. | AI visually "bumps" and reverses course without the position exceeding 4.0. |
| **3. Test MinY Boundary** | Pause the game. Manually set the AI's position to (MinY + 0.1). Force its `targetDirection.y` to **-1**. Resume the game. | The AI's position is clamped to -4.0. The internal `targetDirection.y` flips to **+1**. | AI reverses course without the position dropping below -4.0. |

The player did not break through the wall and was able to stay in the boundaries throughout the test. 
