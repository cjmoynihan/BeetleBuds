using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;

    private Rigidbody2D rb;
    // This variable will accept player movement from either keyboard or controller
    private Vector2 playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerInput();
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
        Vector2 realtimeMovement = playerMovement * playerSpeed * Time.deltaTime;

        rb.MovePosition(rb.position + realtimeMovement);
    }

    public class Stats
    {
        // Put default stats here
        public Stats()
        {

        }
    }
}
