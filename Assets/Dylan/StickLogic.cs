using UnityEngine;
public class StickLogic
{
    private Puck current;

    public void AcquirePuck(Puck p){ current = p;}
    public void ReleasePuck(){ current = null;}
    public bool HasPuck(){ return current != null;} // need to use this when Im done with stuff

    public void performPass(Vector2 aimDir){
        if(current == null) return;
        new Pass().Execute(current, aimDir.normalized);
        ReleasePuck();
    }
    public void performShot(float chargeTime, Vector2 aimDir){ // aim is whatever direction they are moving in at least for now
    // will obviously change it to closest player and in the aim cone of some degree when the game is at least working
        if(current == null) return;
        // maybe a threshold
        Shot s = null; 
        if(chargeTime >= 0.2f) s = new SlapShot(chargeTime);
        if(chargeTime <= 0.19) s = new WristShot();
        s.Execute(current, aimDir.normalized);
        ReleasePuck();

    }
}




public class Pass{
    public void Execute(Puck p, Vector2 targetPosition){
        Vector2 dir = (targetPosition - (Vector2)p.transform.position).normalized;
        float power = 10f;
        p.ApplyImpulse(dir * power); // in Puck script now I believe it should work
    }
}




public abstract class Shot{
    public abstract void Execute(Puck p, Vector2 dir);
}
public class WristShot : Shot{
    public override void Execute(Puck p, Vector2 dir){
        float power = 15f;
        p.ApplyImpulse(power * dir);
    }
}
public class SlapShot : Shot{
    private float charge;
    public SlapShot(float c) { charge = c;}
    public override void Execute(Puck p, Vector2 dir){
        float basePower = 15f; // will update this later as well
        float bonusPower = charge * 1.2f;
        p.ApplyImpulse((basePower + bonusPower) * dir);
    }
}
