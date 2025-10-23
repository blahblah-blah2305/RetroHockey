Boundary Test Documentation: BT-001 Zone Edge Integration (Clamp + Inset + Zero-Axis)
Goal: Verify the skater never penetrates rink bounds, is nudged inside the play area on contact, and the into-wall velocity component is zeroed to prevent sticking.
System Tested: Boundary handling, Rigidbody2D velocity updates, wall contact logic
Parameter	Value
Test Subject	Any AI subclass (e.g., RightDefense) or PlayerController
Bounds	MinX/MaxX/MinY/MaxY from the scene/inspector
Margin (Inset)	0.05f inside the wall after contact
Stop Tolerance	`
Test Procedure
Step	Procedure	Expected Result	Pass/Fail Criteria
1. Setup	Place agent near center; ensure Rigidbody2D is Dynamic, Gravity Scale = 0, Freeze Rotation Z. Disable any random-wander scripts.	Deterministic physics environment.	Setup complete.
2. Drive Left Wall	Force input/targetDir to (-1, 0) until agent reaches MinX.	Agent reaches left boundary.	Reached within 2s (no timeouts).
3. On Contact (Left)	On impact, logic flips X direction or zeroes X, and nudges position to MinX + 0.05f.	Agent visibly insets from wall; no sticking.	pos.x ≥ MinX and pos.x ≥ MinX + 0.05f.
4. Axis Stop (Left)	Immediately after inset (≤0.05s), X-velocity is ~0.	No jitter into wall.	abs(vel.x) ≤ 0.02f.
5. Repeat for Right	Drive (+1, 0) to MaxX, then apply inset MaxX − 0.05f and X-stop.	Same as left.	pos.x ≤ MaxX and pos.x ≤ MaxX − 0.05f; abs(vel.x) ≤ 0.02f.
6. Drive Bottom	Drive (0, −1) to MinY, then inset MinY + 0.05f and Y-stop.	No bottom sticking.	pos.y ≥ MinY and pos.y ≥ MinY + 0.05f; abs(vel.y) ≤ 0.02f.
7. Drive Top	Drive (0, +1) to MaxY, then inset MaxY − 0.05f and Y-stop.	No top sticking.	pos.y ≤ MaxY and pos.y ≤ MaxY − 0.05f; abs(vel.y) ≤ 0.02f.
8. Summary	Log per-wall PASS/FAIL and overall result.	4/4 passes.	All wall checks pass.
Notes observed earlier: When Gravity Scale was left at 1, agents drifted to bottom wall and stuck; setting 0 + applying inset + axis-zero eliminated the issue.
