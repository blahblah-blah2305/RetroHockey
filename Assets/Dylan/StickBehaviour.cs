using UnityEngine;

public class StickBehaviour : MonoBehaviour
{
    public PlayerController owner;

    void OnTriggerEnter2D(Collider2D other){
        var puck = other.GetComponent<Puck>();
        if(puck) owner.AcquirePuck(puck); // need to make this stick to the player. Honestly I dont know how to do this something with transform
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.GetComponent<Puck>()) owner.ReleasePuck(); 
    }

}
