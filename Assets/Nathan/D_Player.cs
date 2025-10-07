using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class D_Player : MonoBehaviour
{
    public string playerKey;
    private Rigidbody2D rb;
    private bool hasPuck = false;
    private bool isOffense = true;
    private float x;
    private float y;
    private PositionHolder positions;
    private Movement movement;
    void Start()
    {
        positions = new PositionHolder();
        rb = GetComponent<Rigidbody2D>();
        movement = new Movement(rb);
    }
    void Update()
    {
        positions.update(playerKey, isOffense, rb.position.x, rb.position.y, rb.linearVelocity.x, rb.linearVelocity.y, hasPuck);




        movement.Move(new Vector2(-1f, 0f));

        var data = positions.get(playerKey);   //simple logging of class to ensure it works
        Debug.Log($"{playerKey} X:{data.x}, Y:{data.y}, puck?:{data.hasPuck}, is offense?:{data.isoffense},xvel:{data.velx},yvel:{data.vely}");        
    }
} 

