using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;

public class D_Player : MonoBehaviour
{
    public string playerKey;
    public bool hasPuck = false;
    public bool isOffense = true;
    private float x;
    private float y;

    private PositionHolder positions;
    void Start()
    {
        positions = new PositionHolder();
    }
    void Update()
    {
        UnityEngine.Vector3 coords = transform.position;
        x = coords.x;
        y = coords.y;

        positions.update(playerKey, isOffense, x, y, hasPuck);


        
        var data = positions.get(playerKey);   //simple logging of class to ensure it works
        Debug.Log($"{playerKey} X:{data.x}, Y:{data.y}, HasPuck:{data.hasPuck}, IsOffense:{data.isoffense}");        
    }
} 

