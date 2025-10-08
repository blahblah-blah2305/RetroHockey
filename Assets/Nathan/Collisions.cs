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

            //knockback logic here:
            const float bounce = 1f / 2f; //bounce back 1/2 power, may update later

            Vector2 kbdirection = (otherplayer.rb.position - player.rb.position).normalized; //calculates direction of hit
            Vector2 victimkb = kbdirection * instagatorspeed * bounce;
            Vector2 instagaterkb = -kbdirection * instagatorspeed * bounce;

            //lowk, the offense or defense could probably smash an oponent against the wall and not get a penalty. oh well, 
            //i may implement that later (not the penalty the play). robbie if ur reading this forget you did, only i want to have the advantage. 

            if (totalforce > 5) //need to expirement with how big this number is.
            {
                Debug.Log($"masssive hit! total force: ({totalforce})");
                //if player has puck loose it fobut make sure u pull first. also i've been using the sample scene so far, i just now pushed that if anyone wants to use it as well but its mainly for testing i guessr sure. 

                //making it a bit arcady, increasing kb with a big hit :D
                victimkb = victimkb * 1.5f;
                instagaterkb = instagaterkb * 1.5f;

                if (instagatordata.hasPuck | victimdata.hasPuck)
                {
                    player.loosepuck();  //these functions have safe exiting, might as well use it for once
                    otherplayer.loosepuck();
                }
                else
                {
                    Debug.Log("big bad time for penalty");
                    //will implement when reset logic is more advanced. also will go man down for 2 minutes. 
                }
            }

            //finally applying kb
            player.rb.AddForce(instagaterkb, ForceMode2D.Impulse);
            otherplayer.rb.AddForce(victimkb, ForceMode2D.Impulse);
            //was going to pause player when hit, this is actually way better. in this case, if a player turns around mid hit, they go FLYING

        }
    }

}

