using UnityEngine;

public class LeftWing : DefensivePlayer
{
    public float maxspeed = 10f; // AI movement
    public float acceleration = 5f;
    public float decceleration = 10f;

    // Defensive Zone Boundaries
    public float MinX = -10.37f;
    public float MaxX = 11.15f;
    public float MinY = -4.45f;
    public float MaxY = 5.46f;

    private float tChange = 0f;
    private Vector2 targetDirection = Vector2.zero;
    private Rigidbody2D rb;

    void Awake()
    {
        // CRITICAL FIX: Call the base class's Awake method FIRST!
        // This initializes the inherited 'stickLogic'.
        base.Awake(); 

        // Get the Rigidbody2D component.
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("LeftWing script requires a Rigidbody2D component.");
        }
    }

    // Use FixedUpdate for physics (Rigidbody2D velocity and Time.fixedDeltaTime).
    void FixedUpdate()
    {
        ExecuteDefenseStrategy();
    }

    public override void ExecuteDefenseStrategy()
    {
        // Ensure Rigidbody is available before proceeding.
        if (rb == null) return;

        Vector2 currentPos = transform.position;
        // FIX: Use rb.velocity instead of rb.linearVelocity
        Vector2 currentVel = rb.linearVelocity; 
        
        // --- Puck Status Check ---
    if (GetHasPuckStatus())
    {
        // AI has the puck – keep moving but at a slower speed for control
        float carrySpeed = maxspeed * 0.6f;
        Vector2 carryVel = targetDirection * carrySpeed;
        rb.linearVelocity = Vector2.MoveTowards(rb.linearVelocity, carryVel, acceleration * Time.fixedDeltaTime);
        Debug.Log(gameObject.name + " is skating with the puck!");
        // Don't return; allow patrol logic to continue below
    }

        // --- Resume Patrol Logic ---

        // 1. Determine Target Direction
        if (Time.time >= tChange)
        {
            float randomX = Random.Range(-1f, 1f);
            float randomY = Random.Range(-1f, 1f);
            targetDirection = new Vector2(randomX, randomY).normalized;

            tChange = Time.time + Random.Range(1.0f, 3.0f);
        }

        // Boundary Bounce Check (with FIX for stopping momentum)
        bool hitBoundary = false;

        // Check X boundaries
        if (currentPos.x >= MaxX || currentPos.x <= MinX)
        {
            targetDirection.x = -targetDirection.x;
            // FIX: Use rb.velocity
            rb.linearVelocity = new Vector2(0, currentVel.y);
            hitBoundary = true;
        }

        // Check Y boundaries
        if (currentPos.y >= MaxY || currentPos.y <= MinY)
        {
            targetDirection.y = -targetDirection.y;
            // FIX: Use rb.velocity
            rb.linearVelocity = new Vector2(currentVel.x, 0);
            hitBoundary = true;
        }
        
        if (hitBoundary)
        {
            tChange = Time.time + Random.Range(0.5f, 1.5f);
        }

        // Acceleration-Based Movement
        Vector2 targetVel = targetDirection * maxspeed;

        // Decide rate
        float rate;
        if (targetVel.magnitude > 0.01f)
        {
            rate = acceleration;
        }
        else
        {
            rate = decceleration;
        }

        // FIX: Use rb.velocity
        rb.linearVelocity = Vector2.MoveTowards(rb.linearVelocity, targetVel, rate * Time.fixedDeltaTime);

        // Clamping 
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