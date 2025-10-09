using UnityEngine;

public class Center : DefensivePlayer
{
    [Header("Random Movement Parameters")]
    public float tChange = 0f;
    public float RandomX = 0f;
    public float RandomY = 0f;
    public float MinX = -8.0f;
    public float MaxX = 4.0f; //keep him on the left side
    public float MinY = -4.0f;
    public float MaxY = 4.0f;

    void Update()
    {
        ExecuteDefenseStrategy();
    }

    // Override the core defense method
    public override void ExecuteDefenseStrategy()
    {
        //direction change 
        if (Time.time >= tChange)
        {
            //set a new random direction, slower movement than player
            RandomX = Random.Range(-1.5f, 1.5f);
            RandomY = Random.Range(-1.5f, 1.5f);


            tChange = Time.time + Random.Range(1.0f, 3.0f);
        }

        transform.Translate(new Vector3(RandomX, RandomY, 0) * Speed * Time.deltaTime);

        //boundary reverse
        //if player hits the edge of zone, reverse direction
        if (transform.position.x >= MaxX || transform.position.x <= MinX)
        {
            RandomX = -RandomX;
        }

        if (transform.position.y >= MaxY || transform.position.y <= MinY)
        {
            RandomY = -RandomY;
        }

        //clamping (Hard Stop
        // Ensure the position stays in zone 
        Vector3 currentPosition = transform.position;
        currentPosition.x = Mathf.Clamp(currentPosition.x, MinX, MaxX);
        currentPosition.y = Mathf.Clamp(currentPosition.y, MinY, MaxY);
        transform.position = currentPosition;

        // TODO: will connect offensive coordinates later
        Debug.Log(gameObject.name + " is currently patrolling its defensive zone.");
    }
}