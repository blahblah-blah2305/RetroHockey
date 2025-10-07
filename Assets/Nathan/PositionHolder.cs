using System;
using UnityEngine;
using System.Collections.Generic;

public class PositionHolder
{
    public class PositionData
    {
        public bool isoffense; //offense = true, defense = false
        public float x;
        public float y;
        public bool hasPuck;

    }


    public class PuckData
    {
        public float puckx;
        public float pucky;
    }

    public PuckData puck = new PuckData();

    public void updatepuck(float newpuckx, float newpucky)
    {
        puck.puckx = newpuckx;
        puck.pucky = newpucky;
    }


    private Dictionary<string, PositionData> positions = new Dictionary<string, PositionData>();

    public void update(string key, bool isoffense, float x, float y, bool hasPuck)
    {
        positions[key] = new PositionData { isoffense = isoffense, x = x, y = y, hasPuck = hasPuck };
    }


    public PositionData get(string key)
    {
        return positions[key];
    }
}