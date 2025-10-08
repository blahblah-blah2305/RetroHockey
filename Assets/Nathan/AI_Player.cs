using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class O_Player : MonoBehaviour
{
    public string playerKey;
    public Rigidbody2D rb; //need to be publick for knockback function
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
        PositionHolder.Instance.updateplayer(playerKey, isOffense, rb.position.x, rb.position.y, rb.linearVelocity.x, rb.linearVelocity.y, hasPuck);

        if (isOffense)
        {
            ologic.DecideAction(PositionHolder.Instance);
        }
        else
        {
            //dlogic.decideaction
            //use this to move around movement.Move(new Vector2(-1f, 0f));
        }
        
        //everything past this point is test code
       
        //var data = PositionHolder.Instance.get(playerKey);   //simple logging of class to ensure it works
        //Debug.Log($"{playerKey} X:{data.x}, Y:{data.y}, puck?:{data.hasPuck}, is offense?:{data.isoffense},xvel:{data.velx},yvel:{data.vely}");        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collisions.hit(this, collision);
    }

    public void loosepuck()
    {
        if (!hasPuck) return;
        Debug.Log(playerKey + "lost the puck");
        hasPuck = false;

    }
} 

