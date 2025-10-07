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
        var data = info.get(playerkey);


        if (data.hasPuck)
        {

            //example, shoot at goal
            Vector2 goalDirection = new Vector2(10f - data.x, 0f).normalized;
            Execute(PuckActions.Shoot, goalDirection);


        }
        else
        {
            //example, skate torwards puck (if puck location was implimented)
            Vector2 goalDirection = new Vector2(10f - data.x, 0f).normalized; 
            Execute(PuckActions.Move, goalDirection);
        }

    }

    public void Execute(PuckActions action, Vector2 direction = default)
    {
        switch (action)
        {
            case PuckActions.Move:
                Debug.Log("moving with puck");
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