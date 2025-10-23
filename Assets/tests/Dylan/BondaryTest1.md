# Boundary Test Documentation: BT-001 Zone Edge Integration

**Goal:**  
Verify that the skater never goes past rink boundaries, is pushed slightly back inside the play area,  
and stops moving toward the wall after contact.

**System Tested:**  
Boundary handling, Rigidbody2D velocity control, wall contact logic

---

## Test Parameters

| Parameter | Value |
|------------|--------|
| Test Subject | Any AI subclass (e.g., `RightDefense`) or `PlayerController` |
| Bounds | `MinX`, `MaxX`, `MinY`, `MaxY` |
| Inset Margin | 0.05f inside the wall after contact |
| Stop Tolerance | `|axisVelocity| ≤ 0.02f` within 0.05s of impact |

---

## Test Procedure

| Step | Procedure | Expected Result | Pass/Fail Criteria |
|------|------------|-----------------|--------------------|
| 1 | **Drive Left Wall** — Move left until reaching `MinX`. | Agent reaches left boundary. | Reaches `MinX` within 2 seconds. |
| 2 | **On Contact (Left)** — Nudge position to `MinX + 0.05f` and stop X movement. | Agent moves slightly inside, no sticking. | `pos.x ≥ MinX + 0.05f`. |
| 3 | **Axis Stop (Left)** — Check X velocity after contact. | X-velocity ≈ 0. | `abs(vel.x) ≤ 0.02f`. |
| 4 | **Right Wall** — Move right until reaching `MaxX`, apply inset and stop. | Same as left. | `pos.x ≤ MaxX - 0.05f`, `abs(vel.x) ≤ 0.02f`. |
| 5 | **Bottom Wall** — Move down until reaching `MinY`, apply inset and stop. | No sticking at bottom. | `pos.y ≥ MinY + 0.05f`, `abs(vel.y) ≤ 0.02f`. |
| 6 | **Top Wall** — Move up until reaching `MaxY`, apply inset and stop. | No sticking at top. | `pos.y ≤ MaxY - 0.05f`, `abs(vel.y) ≤ 0.02f`. |
| 7 | **Summary** — Log all boundaries tested. | 4/4 boundaries passed. | All checks pass. |

---

## Notes

- When **Gravity Scale = 1**, agents stuck to the bottom wall.  
- Setting **Gravity Scale = 0** and applying **inset + velocity zeroing** fixed the issue.

---

**Result:** All boundary checks passed successfully.
