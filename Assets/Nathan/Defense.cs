using System;
using UnityEngine;
using System.Collections.Generic;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


public class Information
{
    public class PositionData
    {
        public bool isoffense; //offense = true, defense = false
        public int x;
        public int y;
        public bool hasPuck;

    }
    private Dictionary<string, PositionData> positions = new Dictionary<string, PositionData>();

    public void update(string key, bool isoffense, int x, int y, bool hasPuck)
    {
        positions[key] = new PositionData { isoffense = isoffense, x = x, y = y, hasPuck = hasPuck };
    }
}



public class OffensivePlayer
{
    //protected Play currentPlay;

    public void DecideAction(Information info)
    {
        //decides what to do
    }

    public void Execute(Action action)
    {
        //executes chosen play
    }
}

