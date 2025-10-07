using UnityEditor.Callbacks;
using UnityEngine;

//requirures rigidbody, will automatically add it if its not there
[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    // you can stop faster, so adding fast decel.
    public float maxspeed = 5f;
    public float acceleration = 10f;
    public float decceleration = 30f;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
    {
        maxspeed = speed;
    }
}
