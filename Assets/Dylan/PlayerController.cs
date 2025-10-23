using UnityEngine;


public class PlayerController : MonoBehaviour
{

    [SerializeField] private Movement movement; // for dragging into the inspector 
    [SerializeField] private bool useHumanInput = true; // this will help with ai or human you just select the box or don't
    [SerializeField] Rigidbody2D rb;
    private StickLogic stick; // passing, shooting
    private PlayerIntent intent = new PlayerIntent(); // prevents null ref 
    private IInputSource source; // where is the input coming from

     private SpriteRenderer sr;

    public void SetInputSource(IInputSource inputSource) { source = inputSource; }



    void Awake(){
            stick = new StickLogic(); 
            rb = GetComponent<Rigidbody2D>();
            sr = GetComponent<SpriteRenderer>();

    }

    void Start(){
        movement = new Movement(rb);
        if(useHumanInput) SetInputSource(new HumanInput()); // player controlled by user
        // else use new AiInput
    }
    void Update(){
        if(source != null) intent = source.GetIntent(); // gets input every fram
        if(intent.passPressed){ 
            Vector2 target = (Vector2)transform.position + intent.aim.normalized * 3f; // this is just basic for now so we can run it
            stick.performPass(target);
        } 
        if(intent.move.x > 0.01f) sr.flipX = true;
        if(intent.move.x < -0.01f) sr.flipX = false;


        if(intent.shotPressed){
            stick.performShot(intent.chargeTime, intent.aim);
        } 
    }
    void FixedUpdate()
    {
        movement.Move(intent.move); // gets the key input to move 

    }
    

    // added this to allow my defense to use the puck status - Robbie
    public bool GetHasPuckStatus()
    {
        return stick.HasPuck();
    } 




    // Call to go to StickLogic
    public void AcquirePuck(Puck p){
        stick.AcquirePuck(p);
    }
    public void ReleasePuck()
    {
        stick.ReleasePuck();
        SMScript.I.PuckHit();
    }
    


}

// overview: gets the input source from AI, User
// 2: stores the intent
// 3: Passes pass shot commands to stick logic
// 4: Handle Puck Ownership at the bottom here
