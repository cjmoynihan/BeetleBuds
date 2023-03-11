using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : StatsController
{
    // Can now get current stats by simply calling them (ie this.health)
    // Updated properties so that any effects added by using AddEffect will
    //  apply their modifiers before those variables are pulled.
    // Setting variables will set the original value, not the modified one
    // Make sure to AddEffect or RemoveEffect when adding status effects or bug parts
    // Check out StatsController for more information

    public int STARTING_HEALTH = 1;
    public int STARTING_SPEED = 2;

    public Rigidbody2D rb;
    // This variable will accept player movement from either keyboard or controller
    private Vector2 playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = STARTING_HEALTH;
        health = STARTING_HEALTH;
        moveSpeed = STARTING_SPEED;

        DontDestroyOnLoad(this.gameObject);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerInput();
        if (health <= 0)
        {
            GameOver();
        }
    }

    public void CauseDamage(int damage)
    {
        health -= damage;
    }

    public void GameOver()
    {
        Destroy(gameObject);
    }

    private void GetPlayerInput()
    {
        // Stick movement
        playerMovement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //playerMovement = new Vector2(0, 0);
        // Keyboard movement
        float xMovement = 0;
        float yMovement = 0;
        if (Input.GetKey(KeyCode.A))
            xMovement -= 1;
        if (Input.GetKey(KeyCode.D))
            xMovement += 1;
        if (Input.GetKey(KeyCode.S))
            yMovement -= 1;
        if (Input.GetKey(KeyCode.W))
            yMovement += 1;
        playerMovement += new Vector2(xMovement, yMovement);
    }

    private void FixedUpdate()
    {
        // Apply movement based on speed and framerate
        Vector2 realtimeMovement = playerMovement * moveSpeed * Time.deltaTime;

        rb.MovePosition(rb.position + realtimeMovement);
    }

    private List<Parts.BugPart> playerParts = new List<Parts.BugPart>();

    public void AddParts(Parts.BugPart part)
    {
        // TODO: Logic to swap out parts of the same type.
        AddEffect(part.applyStats);
        playerParts.Add(part);
    }
}
