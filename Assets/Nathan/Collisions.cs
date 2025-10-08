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
            Vector2 totalimpactvel = collision.relativeVelocity;
            float totalforce = totalimpactvel.magnitude;

            //grabbing velocity , first grabbing keys
            string instigatorkey = player.playerKey;
            string victimkey = otherplayer.playerKey;
            //asking for where they at
            PositionHolder.PositionData instagatordata = PositionHolder.Instance.get(instigatorkey);
            PositionHolder.PositionData victimdata = PositionHolder.Instance.get(victimkey);
            //grabbing velocities now
            Vector2 instagatorvelocity = new Vector2(instagatordata.velx, instagatordata.vely);
            Vector2 victimvelocity = new Vector2(victimdata.velx, victimdata.vely);
            //grabbing speed of each
            float instagatorspeed = instagatorvelocity.magnitude;
            float victimspeed = victimvelocity.magnitude;

            //this function is called for multiple ppl in a collision. only one person should control it. this way,
            //only the instagator (player whos going faster controls it.)
            if (instagatorspeed < victimspeed)
            {
                return;
            }
            else if (instagatorspeed == victimspeed) //for tiebreaker uses the instanceid.
            {
                if (player.gameObject.GetInstanceID() < otherplayer.gameObject.GetInstanceID())
                {
                    return;
                }
            }

            

            Debug.Log($"Victim with: ({victimvelocity}), instagator velocity: ({instagatorvelocity}). magnitude of instagator: ({instagatorspeed}), magnitude of victim: ({victimspeed})");



            //time to add knockback here! this will take a while. will need to freeze player while getting moved back, otherwise they will just
            //deselerate and they will stop quickly. also this will give them a chance to loose a puck on a small hit, but unlickley. on big hit,
            //the puck will just go in the same direction the player went. 


            //lowk, the offense or defense could probably smash an oponent against the wall and not get a penalty. oh well, 
            //i may implement that later (not the penalty the play). robbie if ur reading this forget you did, only i want to have the advantage. 



            if (totalforce > 5) //need to expirement with how big this number is.
            {
                Debug.Log($"masssive hit! total force: ({totalforce})");
                //if player has puck loose it for sure. 


                //if player doesnt have puck its a penalty.
            }


        }
    }

}

