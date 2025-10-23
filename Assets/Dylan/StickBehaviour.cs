using UnityEngine;

public class StickBehaviour : MonoBehaviour // for getting the puck
{
    public PlayerController owner;

    void OnTriggerEnter2D(Collider2D other){
        var puck = other.GetComponent<Puck>();
        if (!puck) return;

        var playerHandler = GetComponentInParent<DefensivePlayer>();

        if(playerHandler != null)
        {
            puck.SetOwner(playerHandler.transform);
            playerHandler.AcquirePuck(puck);
        }
        
    }

    void OnTriggerExit2D(Collider2D other) {
        var puck = other.GetComponent<Puck>();
        if (!puck) return; 
        
        var playerHandler = GetComponentInParent<DefensivePlayer>();

        if(playerHandler != null)
        {
            puck.ReleaseOwner();
            playerHandler.ReleasePuck();
        }
    }

}
