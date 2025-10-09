using UnityEngine;


public abstract class DefensivePlayer : MonoBehaviour
{
    //class attributes
    public float Speed = 5.0f;
    public float CheckDamage = .7f;
    public bool HasPuck = false;
    public Vector3 Location => transform.position;

    //this defines the core defensive logic
    // It must be overridden by subclasses
    public virtual void ExecuteDefenseStrategy()
    {
        //Just maintain position or glide slowly
        Debug.Log(gameObject.name + " is executing generic defense strategy.");
    }
    //method for applying a check or hit.
    public void ApplyCheck()
    {
        Debug.Log(gameObject.name + " pausing player for " + CheckDamage + " seconds.");
        //implement collision logic here
    }
}
