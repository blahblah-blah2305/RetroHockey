# Boundary Test Documentation: BT-001 Zone Edge Integration

**Goal:**  
Makes sure that the skater never goes out of bounds

**System Tested:**  
Boundary handling and collider logic

---

## Test Parameters

| Parameter | Value |
|------------|--------|
| Test Subject | `PlayerController` |
| Bounds | `MinX`, `MaxX`, `MinY`, `MaxY` |

---

## Test Procedure

| Step | Test | Expected Result | Pass/Fail |
|------|------------|-----------------|--------------------|
| 1 | **Drive Left Wall** — Move left until reaching `MinX`. | PlayerController reaches left boundary. | Reaches `MinX` within 3 seconds. |
| 2 | **Axis Stop (Left)** — Check X velocity after contact. | X-velocity ≈ 0.|
| 3 | **Right Wall** — Move right until reaching `MaxX` | Same as left. |
| 4 | **Bottom Wall** — Move down until reaching `MinY`| No sticking at bottom.|
| 5 | **Top Wall** — Move up until reaching `MaxY`| No sticking at top.|
| 6 | **Summary** — All boundaries tested. | 4/4 boundaries passed. | All checks pass. |

---

## Notes

- When **Gravity Scale = 1**, agents stuck to the bottom wall.  
- Setting **Gravity Scale = 0** simply fixed this issue

---

**Result:** All boundary checks passed successfully.
