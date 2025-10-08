using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class O_Player : MonoBehaviour
{
    public string playerKey;
    private Rigidbody2D rb;
    private bool hasPuck = false;
    private bool isOffense = true;
    private float x;
    private float y;
    private Movement movement;
    private OffensivePlayer ologic;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = new Movement(rb);
        ologic = new OffensivePlayer(playerKey, movement);
    }
    void Update()
    {
        PositionHolder.Instance.update(playerKey, isOffense, rb.position.x, rb.position.y, rb.linearVelocity.x, rb.linearVelocity.y, hasPuck);




        ologic.DecideAction(PositionHolder.Instance);




        //everything past this point is test code
        //movement.Move(new Vector2(-1f, 0f));
        //var data = PositionHolder.Instance.get(playerKey);   //simple logging of class to ensure it works
        //Debug.Log($"{playerKey} X:{data.x}, Y:{data.y}, puck?:{data.hasPuck}, is offense?:{data.isoffense},xvel:{data.velx},yvel:{data.vely}");        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collisions.hit(this, collision);
    }
} 

