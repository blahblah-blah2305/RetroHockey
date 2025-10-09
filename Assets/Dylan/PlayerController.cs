using UnityEngine;


public class PlayerController : MonoBehaviour
{

    [SerializeField] private MovementDriver movementDriver; // for dragging into the inspector 
    [SerializeField] private bool useHumanInput = true; // this will help with ai or human you just select the box or don't
    private StickLogic stick; // passing, shooting
    private PlayerIntent intent; 
    private IInputSource source; // where is the input coming from

    public void SetInputSource(IInputSource inputSource) { source = inputSource; }



    void Awake(){
            stick = new StickLogic(); 

    }

    void Start(){
        if(useHumanInput) SetInputSource(new HumanInput()); // player controlled by user
        // else use new AiInput
    }
    void Update(){
        if(source != null) intent = source.GetIntent(); // gets input every fram
        if(intent.passPressed){ 
            Vector2 target = (Vector2)transform.position + intent.aim.normalized * 3f; // this is just basic for now so we can run it
            stick.performPass(target);
        } 


        if(intent.shotPressed) stick.performShot(intent.chargeTime, intent.aim);
    }
    void FixedUpdate(){
        movementDriver.SetMove(intent.move); // gets the key input to move 

    }




    // Call to go to StickLogic
    public void AcquirePuck(Puck p){
        stick.AcquirePuck(p);
    }
    public void ReleasePuck(){
        stick.ReleasePuck();
    }

}

// overview: gets the input source from AI, User
// 2: stores the intent
// 3: Passes pass shot commands to stick logic
// 4: Handle Puck Ownership at the bottom here
