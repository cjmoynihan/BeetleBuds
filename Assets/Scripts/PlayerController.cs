using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : StatsController
{
    public int STARTING_HEALTH = 5;
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
        GetCurrentStats();
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
    public Stats initialStats = new Stats();

    // Define initial stats and create Stats class for Parts.cs
    public class Stats
    {
        public int health;
        public int damage;

        public Stats()
        {
            health = 5;
            damage = 1;
        }

        public Stats Copy()
        {
            return new Stats
            {
                health = health,
                damage = damage
            };
        }
    }

    public void AddParts(Parts.BugPart part)
    {
        // TODO: Logic to swap out parts of the same type.
        playerParts.Add(part);
    }

    public Stats GetCurrentStats()
    {
        Stats tempStats = initialStats.Copy();
        foreach(Parts.BugPart part in playerParts)
        {
            tempStats = part.applyStats(tempStats);
        }
        health = tempStats.health;
        return tempStats;
    }
}
