using UnityEngine;

public class Collisions
{
    public static void hit(O_Player player, Collision2D collision)
    {
        O_Player otherplayer = collision.collider.GetComponent<O_Player>();
        if (otherplayer == null)
        {
            //you hit a wall or other object. maybe the puck lol, we'll have to ensure the puck can't big hit players.
            //sliding logic should be here, no need to big  hit a wall unless we want injuries, which we don't? not yet.

        }
        else
        {
            //player on player hit!
            Debug.Log("impact detected with player!!!!! :D");


            //grabbing impact force of collision
            Vector2 impactvel1 = collision.relativeVelocity;
            float totalforce = impactvel1.magnitude;

            //grabbing velocity (wont work)
            string instigatorkey = player.playerKey;
            string victimkey = otherplayer.playerKey;



            if (totalforce > 10) //need to expirement with how big this number is.
            {
                Debug.Log("masssive hit!");
                //if player has puck loose it for sure. 


                //if player doesnt have puck its a penalty.
            }


        }
    }

}

