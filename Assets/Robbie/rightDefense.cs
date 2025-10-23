using UnityEngine;

public class RightDefense : DefensivePlayer
{
    public float maxspeed = 10f; //AI movement
    public float acceleration = 5f;
    public float decceleration = 10f;

    public float MinX = -10.37f;
    public float MaxX = 11.15f;
    public float MinY = -4.45f;
    public float MaxY = 5.46f;

    private float tChange = 0f;
    private Vector2 targetDirection = Vector2.zero;
    private Rigidbody2D rb;

    void Awake()
    {
        //get the Rigidbody2D component.
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Center script requires a Rigidbody2D component.");
        }
    }

    //use FixedUpdate for physics (Rigidbody2D velocity and Time.fixedDeltaTime).
    void FixedUpdate()
    {
        ExecuteDefenseStrategy();
    }

    public override void ExecuteDefenseStrategy()
    {
        //ensure Rigidbody is available before proceeding.
        if (rb == null) return;

        // 1. Determine Target Direction
        if (Time.time >= tChange)
        {
            float randomX = Random.Range(-1f, 1f);
            float randomY = Random.Range(-1f, 1f);
            targetDirection = new Vector2(randomX, randomY).normalized;

            tChange = Time.time + Random.Range(1.0f, 3.0f);
        }

        //boundary Bounce Check (with FIX for stopping momentum)
        Vector2 currentPos = transform.position;
        Vector2 currentVel = rb.linearVelocity; // Get current velocity for boundary fix

        bool hitBoundary = false;

        //check X boundaries
        if (currentPos.x >= MaxX || currentPos.x <= MinX)
        {
            targetDirection.x = -targetDirection.x;
            //immediately stop velocity on this axis to prevent sticking/overshooting
            rb.linearVelocity = new Vector2(0, currentVel.y);
            hitBoundary = true;
        }

        //check Y boundaries
        if (currentPos.y >= MaxY || currentPos.y <= MinY)
        {
            targetDirection.y = -targetDirection.y;
            //immediately stop velocity on this axis to prevent sticking/overshooting
            rb.linearVelocity = new Vector2(currentVel.x, 0);
            hitBoundary = true;
        }
        
        if (hitBoundary)
        {
            tChange = Time.time + Random.Range(0.5f, 1.5f);
        }

        //acceleration-Based Movement
        Vector2 targetVel = targetDirection * maxspeed;

        //decide rate
        float rate;
        if (targetVel.magnitude > 0.01f)
        {
            rate = acceleration;
        }
        else
        {
            rate = decceleration;
        }

        rb.linearVelocity = Vector2.MoveTowards(rb.linearVelocity, targetVel, rate * Time.fixedDeltaTime);

        //clamping 
        currentPos.x = Mathf.Clamp(currentPos.x, MinX, MaxX);
        currentPos.y = Mathf.Clamp(currentPos.y, MinY, MaxY);
        transform.position = currentPos;

        Debug.Log(gameObject.name + " is currently patrolling its defensive zone.");
    }

    public void SetSpeed(float speed)
    {
        maxspeed = speed;
    }
}