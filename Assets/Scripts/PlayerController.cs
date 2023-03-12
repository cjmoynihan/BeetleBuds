using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public float STARTING_SPEED = 2f;
    public float STARTING_ATTACK_COOLDOWN = 0.5f;
    public float STARTING_DAMAGE = 1f;
    public float STARTING_RANGE = 1f;
    public float PLAYER_SLOW = 0.7f;

    private List<Parts.BugPart> playerParts = new List<Parts.BugPart>();
    public List<GameObject> childPartObjects;

    public Rigidbody2D rb;
    // This variable will accept player movement from either keyboard or controller
    private Vector2 playerMovement;
    public float magnitude
    {
        get
        {
            return playerMovement.magnitude;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = STARTING_HEALTH;
        health = STARTING_HEALTH;
        moveSpeed = STARTING_SPEED;
        attackCooldown = STARTING_ATTACK_COOLDOWN;
        attackDamage = STARTING_DAMAGE;
        attackRange = STARTING_RANGE;
        playerSlow = PLAYER_SLOW;

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        // Organize child parts by part type
        childPartObjects = Enumerable.ToList<GameObject>(childPartObjects.OrderBy(obj => (int)obj.GetComponent<Parts.BugPart>().slot));
        // Add in player parts
        foreach(GameObject childManager in childPartObjects)
        {
            Parts.BugPart bp = childManager.GetComponent<Parts.BugPart>();
            playerParts.Add(bp);
            AddEffect(bp.applyStats);
        }

        //// Organize bug parts by part. Important for correct swapping
        //var tempParts = playerParts.OrderBy(part => (int)part.slot);
        //playerParts = Enumerable.ToList<Parts.BugPart>(tempParts);

        ////playerParts = (List<Parts.BugPart>)playerParts.OrderBy(part => (int)part.slot);
        //// Add effects to stats
        //foreach(Parts.BugPart part in playerParts)
        //{
        //    AddEffect(part.applyStats);
        //}

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerInput();
        if (ModifiedStats.health <= 0)
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
        anim.SetBool("IsDead", true);
        //Destroy(gameObject);
    }

    private void GetPlayerInput()
    {
        // Stick movement
        playerMovement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        playerMovement = new Vector2(0, 0);
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
        if (xMovement != 0 | yMovement != 0)
        {
            anim.SetBool("PlayerWalking", true);
        }
        else
        {
            anim.SetBool("PlayerWalking", false);
        }
        playerMovement += new Vector2(xMovement, yMovement);
    }

    private void FixedUpdate()
    {
        // Apply movement based on speed and framerate
        Vector2 realtimeMovement = playerMovement * ModifiedStats.moveSpeed * Time.deltaTime;

        rb.MovePosition(rb.position + realtimeMovement);
    }

    public void AddParts(Parts.BugPart newPart)
    {
        // Logic to swap out parts of the same type.
        GameObject childManager = childPartObjects[(int)newPart.slot];
        // Swap scripts

        // Legacy code:
        Parts.BugPart oldComponent = childManager.GetComponent<Parts.BugPart>();
        //newPart.childrenSprites = oldComponent.childrenSprites;
        // :End legacy code

        Component newComponent = childManager.AddComponent(newPart.GetType());
        //Destroy(GetComponent(oldComponent.GetType()));  // Not destroying component!!
        Destroy(oldComponent);

        // Swap sprites
        SpriteRenderer[] childRenderers = childManager.GetComponentsInChildren<SpriteRenderer>();
        if (childRenderers.Length == 1)
        {
            childRenderers[0].sprite = newPart.partSprite;
        } else
        {
            for (int idx = 0; idx < childRenderers.Length; idx++)
            {
                childRenderers[idx].sprite = newPart.childrenSprites[idx];
            }
        }

        //Parts.BugPart newScript = childManager.GetComponent
        //Parts.BugPart inplaceScript = childManager.GetComponent(newPart.GetType());
        //newPart.ReplaceSprites();


        // Add new parts to logic
        // Remove old parts from logic
        Parts.BugPart previousPart = playerParts[(int)newPart.slot];
        RemoveEffect(previousPart.applyStats);
        AddEffect(newPart.applyStats);
        playerParts[(int)newPart.slot] = newPart;
    }
}
