using UnityEngine;

public class HumanInput : IInputSource // should do the same thing for AI
{
    private float holdButton;

    public PlayerIntent GetIntent(){
        Vector2 move = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        ).normalized;

        // Aim same direction as move
        Vector2 aim = (move == Vector2.zero) ? Vector2.right : move;


        return new PlayerIntent{
             move = move,
             aim = (move == Vector2.zero ? Vector2.right : move.normalized),
             passPressed = Input.GetKeyDown(KeyCode.P),
             shotPressed = Input.GetKeyDown(KeyCode.Space),
             chargeTime = 100f
        };
    }
}
