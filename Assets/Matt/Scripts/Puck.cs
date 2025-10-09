using UnityEngine;

public class Puck : MonoBehaviour
{
	public Rigidbody2D rigidbody2d;
	public float puck_speed;
	// Tranform owner;
	Vector2 holdOffset = new Vector2(0.35f, 0f);
	private PositionHolder positionHolder;


	void Awake(){
		// rigidbody2d = GetComponent<rigidbody2d>();
	}
    void Update()
    {
		//keeps track of puck position and velocity
        PositionHolder.Instance.updatepuck(rigidbody2d.position.x, rigidbody2d.position.y, rigidbody2d.linearVelocity.x, rigidbody2d.linearVelocity.y);
    }

    public void SetPositionHolder(PositionHolder holder)
	{
		positionHolder = holder;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Playerscore")
		{
			updatepuck(0, 0);
		}
		if (collision.gameObject.tag == "Enemy_score")
		{
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

}
