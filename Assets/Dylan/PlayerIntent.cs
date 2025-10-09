using UnityEngine;

public class PlayerIntent // what is the player trying to do
{
    public Vector2 move, aim;
    public bool passPressed, shotPressed;
    public float chargeTime;
}

public interface IInputSource{ // use GetIntent for access to what any player is doing AI or keyboard input
// also interfaces start with I thats why we cant just call it InputSource
    PlayerIntent GetIntent(); 
}

// prob going to need to do a AIInput : INNputSource{
    // public PlayerIntent = new PlayerIntent
//}