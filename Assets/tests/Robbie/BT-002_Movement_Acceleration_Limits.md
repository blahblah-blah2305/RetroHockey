# Boundary Test Documentation: BT-002 Movement Acceleration Limits

**Goal:** Verify velocity is strictly capped at `maxspeed` and confirm that the `decceleration` rate provides a distinct, quick-stop effect.

**System Tested:** Acceleration/Deceleration Logic, Rigidbody2D Velocity

| Parameter | Value |
| :--- | :--- |
| Test Subject | LeftWing (or any AI subclass) |
| Target Maxspeed | 3.0 |
| Deceleration Rate | 10.0 |

---

## Test Procedure

| Step | Procedure | Expected Result | Pass/Fail Criteria |
| :--- | :--- | :--- | :--- |
| **1. Setup (Low Maxspeed)** | Set the AI's **Maxspeed** to **3.0**. Set **Acceleration** to **10.0**. Ensure **Deceleration** is **10.0**. | AI should be configured for a controlled velocity test. | *Setup Complete* |
| **2. Verify Velocity Cap** | Force the AI's movement input (`targetDirection`) to a constant value of **(1, 1)** for at least 2 seconds. | The AI's **`rb.velocity.magnitude`** (viewed in the Inspector) must accelerate up to **3.0f** and **not exceed it**. | `rb.velocity.magnitude` must be $\leq 3.0f$. |
| **3. Verify Deceleration** | While the AI is moving at max speed (3.0f), set the input (`targetDirection`) to **(0, 0)**. | The AI should come to a complete stop very quickly (e.g., in $\approx 0.3$ seconds) due to the higher deceleration rate. | The stopping time is demonstrably faster than the time taken to reach max speed. |