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
    private StickLogic stickLogic;

    private Vector2 targetGoalPosition = new Vector2(10f, 0f); //todo : change to handle turnovers

    //variables to help aiming before shooting:
    private bool prepshot = false;
    private bool prepass = false;
    private float actiontimer = 0f;
    private Vector2 actionvector; // direction to aim
    private const float prepptime = 0.2f; // how long im aiming for

    public OffensivePlayer(string key, Movement mov, StickLogic stick)
    {
        playerkey = key;
        movement = mov;
        stickLogic = stick;
    }
    public OffensivePlayer() { }





    public void DecideAction(PositionHolder info, float deltaTime)
    {
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
        Vector2 myPosition = new Vector2(mydata.x, mydata.y);
        float distanceToGoal = Vector2.Distance(myPosition, targetGoalPosition);
        Vector2 directionToGoal = (targetGoalPosition - myPosition).normalized;

        // 1. SHOOT LOGIC: If close to the goal, shoot.
        if (distanceToGoal < 7f) // Arbitrary "shooting range"
        {
            Debug.Log(playerkey + " deciding to SHOOT!");
            Execute(PuckActions.Shoot, directionToGoal); // Pass aim direction
            return; // Action decided
        }

        // 2. PASS LOGIC: Find a teammate who is closer to the goal.
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
            Debug.Log(playerkey + " deciding to PASS to " + passTarget.GetHashCode());
            Vector2 passTargetPosition = new Vector2(passTarget.x, passTarget.y);
            Execute(PuckActions.Pass, passTargetPosition); // Pass target *position*
            return; // Action decided
        }

        // 3. MOVE LOGIC: If not shooting or passing, skate towards the goal.
        Debug.Log(playerkey + " moving towards goal");
        Execute(PuckActions.Move, directionToGoal);
    }
    
    private void decideoffballaction(PositionHolder.PositionData mydata, PositionHolder info)
    {
    Vector2 myPosition = new Vector2(mydata.x, mydata.y);
    

    //check if someone has the puck
    PositionHolder.PositionData puckCarrier = info.playerwithpuck();

    if (puckCarrier == null)
    {
            // move torwards puck

            Vector2 puckPosition = info.GetPuckPosition();
            Debug.Log(puckPosition);
            Vector2 directionToPuck = (puckPosition - myPosition).normalized;
            Execute(PuckActions.Move, directionToPuck);
            //Debug.Log("gotorwardspuck");

       
    }
    else
        {
            //get open?
            Debug.Log("getopen");
        Vector2 carrierPosition = new Vector2(puckCarrier.x, puckCarrier.y);
        Vector2 directionToCarrier = (carrierPosition - myPosition).normalized;
        Execute(PuckActions.Move, directionToCarrier);
    }
    }


    public void Execute(PuckActions action, Vector2 direction = default)
    {
        switch (action)
        {
            case PuckActions.Move:
                prepshot = false;
                prepass = false;
                movement.Move(direction);
                break;
            case PuckActions.Shoot:
                Debug.Log("shooting!");
                prepshot = true;
                prepass = false;
                actiontimer = prepptime;
                actionvector = direction;
                break;
            case PuckActions.Pass:
                Debug.Log("passing now");
                prepshot = false;
                prepass = true;
                actiontimer = prepptime;
                actionvector = direction;
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