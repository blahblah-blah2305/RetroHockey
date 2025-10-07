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

    public PuckData puck = new PuckData();

    public void updatepuck(int newpuckx, int newpucky)
    {
        puck.puckx = newpuckx;
        puck.pucky = newpucky;
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