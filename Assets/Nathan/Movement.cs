using UnityEditor.Callbacks;
using UnityEngine;

public class Movement
{
    // you can stop faster, so adding fast decel.
    public float maxspeed = 5f;
    public float acceleration = 2f;
    public float decceleration = 10f;

    private Rigidbody2D rb;
    
    public Movement(Rigidbody2D rigidbody)
    {
    rb = rigidbody;
    }

    public void Move(Vector2 input)
    {
        Vector2 targetvel = input.normalized * maxspeed;

        //deciding if u we should use accel or decel rate
        float rate;
        if (input.magnitude > 0)
        {
            rate = acceleration;
        }
        else
        {
            rate = decceleration;
        }
        rb.linearVelocity = Vector2.MoveTowards(rb.linearVelocity, targetvel, rate * Time.fixedDeltaTime);
        //code VERY loosely based off of https://discussions.unity.com/t/object-moving-and-acceleration/721314
    }
    public void setspeed(float speed) //function will be used for bc mode and for difficulty changes
    //could possibly change this to acceleration and speed to be updated? we'll need to see how much harder it is when the game works. 
    {
        maxspeed = speed;
    }
}
