/*using UnityEngine;

public class Puck : MonoBehaviour
{
	public Rigidbody2D rigidbody2d;
	public Collider2D col;
	public float puck_speed;
	Transform owner;
	Vector2 holdOffset = new Vector2(0.4f, -0.4f);
	private PositionHolder positionHolder;
	public SpriteRenderer puckSR;
	public gameObject cam;
    public Transform CurrentOwner => owner;


	void Awake(){
		rigidbody2d = GetComponent<Rigidbody2D>();
		col = GetComponent<Collider2D>();
	}
void Update()
{
    if (owner == null) return;

    
    SpriteRenderer ownerSR = owner.GetComponent<SpriteRenderer>();
    float side;
    if (ownerSR != null)
        side = ownerSR.flipX ? 1f : -1f;       
    else
        side = Mathf.Sign(owner.localScale.x);   

    // switches the puck sprite with the player
    Vector2 pos = (Vector2)owner.position + new Vector2(Mathf.Abs(holdOffset.x) * side, holdOffset.y);
    transform.position = pos;

    // Freeze motion while held
    rigidbody2d.linearVelocity = Vector2.zero;
    rigidbody2d.angularVelocity = 0f;

    if (puckSR != null && ownerSR != null)
        puckSR.flipX = ownerSR.flipX;

    if (positionHolder != null)
    {
        positionHolder.updatepuck(rigidbody2d.position.x, rigidbody2d.position.y, rigidbody2d.linearVelocity.x, rigidbody2d.linearVelocity.y);
    }
    else if (PositionHolder.Instance != null)
    {
        PositionHolder.Instance.updatepuck(rigidbody2d.position.x, rigidbody2d.position.y, rigidbody2d.linearVelocity.x, rigidbody2d.linearVelocity.y);
	}
}
    public void SetPositionHolder(PositionHolder holder)
    {
        positionHolder = holder;
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player_score")
		{
			SMScript.I.GoalHorn();
			updatepuck(0, 0);
		}
		if (collision.gameObject.tag == "Enemy_score")
		{
			SMScript.I.GoalHorn();
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
} */
