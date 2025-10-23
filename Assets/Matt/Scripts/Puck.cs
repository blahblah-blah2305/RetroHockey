using UnityEngine;

public class Puck : MonoBehaviour
{
    public Rigidbody2D rigidbody2d;
    public Collider2D col;
    public float puck_speed;
    private Transform owner; // Who currently holds the puck
    public Vector2 holdOffset = new Vector2(0.5f, 0f);
    private PositionHolder positionHolder;

    public Transform CurrentOwner => owner;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (owner == null) return;

        // Calculate offset in LOCAL space
        Vector2 localOffset = new Vector2(holdOffset.x, holdOffset.y);
        Vector2 pos = owner.TransformPoint(localOffset); // Converts local offset to world position
        transform.position = pos;

        // Freeze motion while held
        rigidbody2d.linearVelocity = Vector2.zero;
        rigidbody2d.angularVelocity = 0f;

        // Update position in PositionHolder (if exists)
        if (PositionHolder.Instance != null)
        {
            PositionHolder.Instance.updatepuck(
                rigidbody2d.position.x,
                rigidbody2d.position.y,
                rigidbody2d.linearVelocity.x,
                rigidbody2d.linearVelocity.y
            );
        }
    }

    public void SetPositionHolder(PositionHolder holder)
    {
        positionHolder = holder;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Prevent puck reset if being held
        if (owner != null) return;

        if (collision.gameObject.CompareTag("Playerscore") ||
            collision.gameObject.CompareTag("Enemy_score"))
        {
            updatepuck(0, 0);
        }
    }

    public void updatepuck(float x, float y)
    {
        rigidbody2d.MovePosition(new Vector2(x, y));
    }

    public void ApplyImpulse(Vector2 impulse)
    {
        rigidbody2d.AddForce(impulse, ForceMode2D.Impulse);
    }

    public void SetOwner(Transform t)
    {
        owner = t;

        Collider2D puckCollider = GetComponent<Collider2D>();
        Collider2D ownerCollider = owner.GetComponent<Collider2D>();

        if (puckCollider != null && ownerCollider != null)
        {
            Physics2D.IgnoreCollision(puckCollider, ownerCollider, true);
        }

        rigidbody2d.bodyType = RigidbodyType2D.Kinematic;
        if (col) col.isTrigger = true;
    }

    public void ReleaseOwner()
    {
        if (owner != null)
        {
            Collider2D puckCollider = GetComponent<Collider2D>();
            Collider2D ownerCollider = owner.GetComponent<Collider2D>();

            if (puckCollider != null && ownerCollider != null)
            {
                Physics2D.IgnoreCollision(puckCollider, ownerCollider, false);
            }

            transform.SetParent(null);
            owner = null;

            rigidbody2d.bodyType = RigidbodyType2D.Dynamic;
            if (col) col.isTrigger = false;
        }
    }
}
