using System;
using UnityEngine;
using System.Collections.Generic;

public class PositionHolder
{
    public class PositionData
    {
        public bool isoffense; //offense = true, defense = false
        public int x;
        public int y;
        public bool hasPuck;

    }


    public class PuckData
    {
        public int puckx;
        public int pucky;
    }

    public void updatepuck(int puckx, int pucky)
    {
        pucky = pucky;
        puckx = puckx;
    }


    private Dictionary<string, PositionData> positions = new Dictionary<string, PositionData>();

    public void update(string key, bool isoffense, int x, int y, bool hasPuck)
    {
        positions[key] = new PositionData { isoffense = isoffense, x = x, y = y, hasPuck = hasPuck };
    }


    public PositionData get(string key)
    {
        return positions[key];
    }
}



public class OffensivePlayer
{
    //protected Play currentPlay;

    public void DecideAction(PositionHolder info)
    {
        //decides what to do
    }

    public void Execute(Action action)
    {
        //executes chosen play
    }
}

