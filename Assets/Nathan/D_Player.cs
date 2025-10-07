using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;

public class D_Player : MonoBehaviour
{
    public string playerKey;
    public bool hasPuck = false;
    public bool isOffense = true;
    private int x;
    private int y;

    private PositionHolder positions;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OffensivePlayer player = new OffensivePlayer();
        PositionHolder positions = new PositionHolder();

        
    }

    // Update is called oncae per frame
    void Update()
    {
        UnityEngine.Vector3 coords = transform.position;
        x = (int)coords.x;
        y = (int)coords.y;

        positions.update(playerKey, isOffense, x, y, hasPuck);
        
    }
} 

public class OffensiveTeamPlay : OffensivePlayer
{
    public void PickTeamPlay(int play)
    {
        
    }
}