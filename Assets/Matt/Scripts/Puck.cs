using UnityEngine;

public class Puck : MonoBehaviour
{
	public Rigidbody2D rigidbody2d;
	public float puck_speed;
	private PositionHolder positionHolder;

	public void SetPositionHolder(PositionHolder holder){
		positionHolder = holder;
	}

	private void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.tag == "Playerscore"){
			updatepuck(0,0);
		}
		if (collision.gameObject.tag == "Enemy_score"){
			updatepuck(0,0);
		}
	}

	public void updatepuck( float x, float y ){
		rigidbody2d.MovePosition(new Vector2(x,y));
		if( positionHolder != null){
			positionHolder.updatepuck(x,y);
		}
	}

}
