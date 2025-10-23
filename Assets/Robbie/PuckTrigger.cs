using UnityEngine;

public class PuckTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        var puck = other.GetComponent<Puck>();
        if (!puck) return;

        var playerHandler = GetComponentInParent<DefensivePlayer>();
        if (playerHandler != null && !playerHandler.GetHasPuckStatus())
        {
            puck.SetOwner(playerHandler.transform);
            playerHandler.AcquirePuck(puck);
        }
    }

    // Remove OnTriggerExit2D — puck should stay attached until collision
}
