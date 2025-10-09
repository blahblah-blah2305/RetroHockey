using UnityEngine;

public class MovementDriver : MonoBehaviour // The actual movement using the other script for logic
{
    public Rigidbody2D rb;
    private Movement movement;
    private Vector2 pendingMove;
    void Awake()
    {
        movement = new Movement(rb);
    }

    public void SetMove(Vector2 move){
        pendingMove = move; // called in fixedUpdate in playerController
    }
    void FixedUpdate()
    {
        movement.Move(pendingMove);  // Uses Nathans logic for moving
    }
}
