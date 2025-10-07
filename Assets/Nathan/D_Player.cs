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
        UnityEngine.Vector3 coords = transform.position;
        x = coords.x;
        y = coords.y;
        positions.update(playerKey, isOffense, x, y, hasPuck);


        movement.Move(new Vector2(-1f, 0f));

        var data = positions.get(playerKey);   //simple logging of class to ensure it works
        Debug.Log($"{playerKey} X:{data.x}, Y:{data.y}, HasPuck:{data.hasPuck}, IsOffense:{data.isoffense}");        
    }
} 

