using System;
using UnityEngine;
using System.Collections.Generic;

public class PositionHolder : MonoBehaviour
{

    public static PositionHolder Instance
    {
        get;
        private set;
    }
    public class PositionData
    {
        public bool isoffense; //offense = true, defense = false
        public float x, y, velx, vely;
        public bool hasPuck;

    }


    public class PuckData
    {
        public float puckx, pucky, puckxvel, puckyvel;
    }

    public PuckData puck = new PuckData();

    public void updatepuck(float newpuckx, float newpucky, float pxvel, float pyvel)
    {
        puck.puckx = newpuckx;
        puck.pucky = newpucky;
        puck.puckxvel = pxvel;
        puck.puckyvel = pyvel;
    }


    public Dictionary<string, PositionData> positions = new Dictionary<string, PositionData>();


    // ensures only one of this data structure exists, no duplicates
    //useing awake not start so this runs first
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    //updates player position
    public void update(string key, bool isoffense, float x, float y, float xv, float yv, bool hasPuck)
    {
        positions[key] = new PositionData { isoffense = isoffense, x = x, y = y, velx = xv, vely = yv, hasPuck = hasPuck };

        // turnover logic below
        if (!isoffense && hasPuck)
        {
            foreach (var kvp in positions)
            {
                kvp.Value.isoffense = !kvp.Value.isoffense;
                Debug.Log("turnover, flipped players");
            }
        }
    }

    //used when wanting to reference one player
    public PositionData get(string key)
    {
        return positions[key];
    }

    //finds player with puck
    public PositionData playerwithpuck()
    {
        foreach (var playdata in positions.Values)
        {
            if (playdata.hasPuck)
            {
                return playdata;
            }
        }
        return null;
    }
    
}