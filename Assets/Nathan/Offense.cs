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
        if (movement == null) Debug.LogError(playerkey + ": movement is NULL!");
        if (stickLogic == null) Debug.LogError(playerkey + ": stickLogic is NULL!");    
        var mydata = info.get(playerkey);
        if (mydata == null)
        {
            return; //stops stupid stinking race conditions i hate unity
        }

        Vector2 myposition = new Vector2(mydata.x, mydata.y);

        if (prepshot || prepass) //keep moving if we are preparing to shoot or pass. 
        {
            movement.Move(actionvector);
            actiontimer -= deltaTime;
            if (actiontimer <= 0f)
            {
                if (prepshot)
                {
                    prepshot = false;
                    stickLogic.performShot(0.1f, actionvector); // Shoot!   
                }
                else
                {
                    prepass = false;
                    stickLogic.performPass(actionvector);
                }

            }
            return;
        }

        if (mydata.hasPuck) //ai player has puck
        {
            decideonballaction(mydata, info);
        }
        else //ai player does not have puck
        {
            decideoffballaction(mydata, info);
        }

    }



    private void decideonballaction(PositionHolder.PositionData mydata, PositionHolder info)
    {
        Vector2 myposition = new Vector2(mydata.x, mydata.y);
        float distanceToGoal = Vector2.Distance(myposition, targetGoalPosition);
        Vector2 directionToGoal = (targetGoalPosition - myposition).normalized;

        //shoot if close enough
        if (distanceToGoal < 2f) // Arbitrary "shooting range"
        {
            Execute(PuckActions.Shoot, directionToGoal);
            return; 
        }

        //pass if a teamate is close enough. 
        PositionHolder.PositionData passTarget = null;
        foreach (var kvp in info.positions)
        {
            if (kvp.Key == playerkey) continue; // Skip self

            // TODO: Add team-checking logic here!
            Vector2 otherPlayerPos = new Vector2(kvp.Value.x, kvp.Value.y);
            float targetDistToGoal = Vector2.Distance(otherPlayerPos, targetGoalPosition);

            if (targetDistToGoal < distanceToGoal)
            {
                passTarget = kvp.Value;
                break;
            }
        }

        if (passTarget != null)
        {
            Vector2 passTargetPosition = new Vector2(passTarget.x, passTarget.y);
            Execute(PuckActions.Pass, passTargetPosition); // Pass target *position*
            return;
        }
        
        //skating torwards goal
        Debug.Log(playerkey + " moving towards goal");
        Execute(PuckActions.Move, directionToGoal);
    }
    
    private void decideoffballaction(PositionHolder.PositionData mydata, PositionHolder info)
    {
        Vector2 myposition = new Vector2(mydata.x, mydata.y);
        var puckCarrier = info.playerwithpuck();
        if (puckCarrier == null)
        {
            // no o player has the puck, its prob being passed. 
            if (info.puck != null)
            {
                Vector2 puckypos = new Vector2(info.puck.puckx, info.puck.pucky);
                Vector2 direction2puck = (puckypos - myposition).normalized;

                //move in that new dir
                movement.Move(direction2puck);
            }
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