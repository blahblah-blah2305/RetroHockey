using System;
using UnityEngine;
using System.Collections.Generic;

public enum PuckActions
{
    Move,
    Shoot,
    Pass
}

public class OffensivePlayer
{
    private Movement movement;
    private string playerkey;

    public OffensivePlayer(string key, Movement mov)
    {
        playerkey = key;
        movement = mov;
    }
    public OffensivePlayer() { }
    public void DecideAction(PositionHolder info)
    {
        var mydata = info.get(playerkey);
        if (mydata == null)
        {
            return; //stops stupid stinking race conditions i hate unity
        }
        var allplayers = info.positions;

        PositionHolder.PositionData target = null; //target is who we skate torwards
                                                   //simple logic to find who to target, in this case its anyone who isnt us. 

        foreach (var kvp in info.positions)
        {
            if (kvp.Key != playerkey)
            {
                target = kvp.Value;
                break;
            }
        }

        if (target != null) //unity fix ur race conditions (im the problem)
        {
            // found other player now we hit them :D
            Vector2 direction = new Vector2(target.x - mydata.x, target.y - mydata.y).normalized;
            Execute(PuckActions.Move, direction);
        }
        



/* will put this back, just testing collisions
                                if (mydata.hasPuck)
                                {

                                }
                                else
                                {
                                    //normally else would be if the player doesnt have puck. rn just testing to make sure it skates torwards anyone else. 

                                    //example play, keep comments for reference. 
                                    //example, skate torwards puck (if puck location was implimented)
                                    //Vector2 goalDirection = new Vector2(10f - data.x, 0f).normalized;
                                    //Execute(PuckActions.Move, goalDirection);
                                }
                                */

    }


    public void Execute(PuckActions action, Vector2 direction = default)
    {
        switch (action)
        {
            case PuckActions.Move:
                movement.Move(direction);
                break;
            case PuckActions.Shoot:
                Debug.Log("shooting!");
                movement.Move(direction);
                //player doesn't have to move far, they just start moving torwards goal
                //will steal implimentation of puck shooting from dylan's player controls
                break;
            case PuckActions.Pass:
                Debug.Log("passing now");
                movement.Move(direction);
                //turn torwards player you want to pass to, doesnt need to move far.
                //also will steal dylans implimentation when its up
                break;
        }

    }
}


public class OffensiveTeamPlay : OffensivePlayer
{
    public void PickTeamPlay(int play)
    {
        
    }
}