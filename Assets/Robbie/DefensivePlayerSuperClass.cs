using UnityEngine;


public abstract class DefensivePlayer : MonoBehaviour
{
    // Class attributes
    public float Speed = 5.0f;
    public float CheckDamage = .7f;
    public Vector3 Location => transform.position;

    // --- PUCK HANDLING FIELDS ---
    private StickLogic stickLogic;
    // ----------------------------

    // CRITICAL FIX: Use 'protected' so subclasses can call 'base.Awake()'
    protected void Awake() 
    {
        // Initialize the StickLogic instance for this player
        stickLogic = new StickLogic();
    }

    // --- PUCK HANDLING METHODS (Inherited by all AI) ---

    // Required by StickBehaviour.cs to take ownership
    public void AcquirePuck(Puck p)
    {
        stickLogic.AcquirePuck(p);
    }

    // Required by StickBehaviour.cs to drop ownership
    public void ReleasePuck()
    {
        stickLogic.ReleasePuck();
    }

    // Used by the AI defense strategy to check if it has the puck
    public bool GetHasPuckStatus()
    {
        // This will now be safe because Awake() is guaranteed to run first
        return stickLogic.HasPuck();
    }
    
    // ----------------------------------------------------

    // This defines the core defensive logic (must be overridden)
    public virtual void ExecuteDefenseStrategy()
    {
        //Just maintain position or glide slowly
        Debug.Log(gameObject.name + " is executing generic defense strategy.");
    }

    // method for applying a check or hit.
    public void ApplyCheck()
    {
        Debug.Log(gameObject.name + " pausing player for " + CheckDamage + " seconds.");
        // implement collision logic here
    }
   protected virtual void OnCollisionEnter2D(Collision2D collision)
{
    // Only react to collisions with other defensive players
    if (collision.gameObject.GetComponent<DefensivePlayer>() != null)
    {
        var puck = FindObjectOfType<Puck>();
        if (puck != null && puck.CurrentOwner == transform)
        {
            puck.ReleaseOwner();
            ReleasePuck();

            // Optional: add impulse to simulate puck drop
            Vector2 impulse = (puck.transform.position - transform.position).normalized * 2f;
            puck.ApplyImpulse(impulse);

            Debug.Log(gameObject.name + " lost the puck on collision with another player.");
        }
    }
}


}