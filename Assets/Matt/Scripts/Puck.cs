using UnityEngine;

public class Puck : MonoBehaviour
{
	public Rigidbody2D rigidbody2d;
	public Collider2D col;
	public float puck_speed;
	Transform owner;
	Vector2 holdOffset = new Vector2(0.5f, 0.5f);
	private PositionHolder positionHolder;


	void Awake(){
		rigidbody2d = GetComponent<Rigidbody2D>();
		col = GetComponent<Collider2D>();
	}
    void Update()
    {
		 if (owner == null) return;
  
        Vector2 ahead = (Vector2)owner.right;            
        Vector2 pos = (Vector2)owner.position + ahead.normalized * holdOffset.x + Vector2.up * holdOffset.y;
        transform.position = pos;

        rigidbody2d.linearVelocity = Vector2.zero;                       // freeze motion while held
        rigidbody2d.angularVelocity = 0f;
		//keeps track of puck position and velocity
        if (positionHolder != null)
        {
            positionHolder.updatepuck(GetComponent<Rigidbody2D>().position.x, GetComponent<Rigidbody2D>().position.y, GetComponent<Rigidbody2D>().linearVelocity.x, GetComponent<Rigidbody2D>().linearVelocity.y);
        }
        else if (PositionHolder.Instance != null)
        {
            PositionHolder.Instance.updatepuck(GetComponent<Rigidbody2D>().position.x, GetComponent<Rigidbody2D>().position.y, GetComponent<Rigidbody2D>().linearVelocity.x, GetComponent<Rigidbody2D>().linearVelocity.y);
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

	//this should be the function that resets the puck position.
	public void updatepuck(float x, float y)
	{
		rigidbody2d.MovePosition(new Vector2(x, y));
		
	}
	public void ApplyImpulse(Vector2 impulse){
		rigidbody2d.AddForce(impulse, ForceMode2D.Impulse);
	}

public void SetOwner(Transform t){ owner = t; rigidbody2d.bodyType = RigidbodyType2D.Kinematic; if(col) col.isTrigger = true; }
public void ReleaseOwner(){ owner = null; rigidbody2d.bodyType = RigidbodyType2D.Dynamic; if(col) col.isTrigger = false;}

}

