using UnityEngine;

public class StickBehaviour : MonoBehaviour // for getting the puck
{
    public PlayerController owner;

    void OnTriggerEnter2D(Collider2D other){
        var puck = other.GetComponent<Puck>();
        if(!puck) return;
        
        puck.SetOwner(owner.transform);
        owner.AcquirePuck(puck);
    }

    void OnTriggerExit2D(Collider2D other) {
        var puck = other.GetComponent<Puck>();
        if(!puck) return; 
            puck.ReleaseOwner();
            owner.ReleasePuck();
    }

}
