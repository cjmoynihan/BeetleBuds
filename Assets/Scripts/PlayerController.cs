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
    public float SLOW_DURATION = 0.7f;

    private List<Parts.BugPart> playerParts = new List<Parts.BugPart>();
    public List<GameObject> childPartObjects;
    public List<Sprite> currentSprites = new List<Sprite>();

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
        slowDuration = SLOW_DURATION;

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        // Organize child parts by part type
        childPartObjects = Enumerable.ToList<GameObject>(childPartObjects.OrderBy(obj => (int)obj.GetComponent<Parts.BugPart>().slot));
        // Add in player parts
        foreach(GameObject childPart in childPartObjects)
        {
            playerParts.Add(null);
            AddParts(childPart.GetComponent<Parts.BugPart>());


            //Parts.BugPart bp = childManager.GetComponent<Parts.BugPart>();
            //playerParts.Add(bp);
            //AddEffect(bp.applyStats);
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
        // Get all children of this
        // Get all children of that (grandchildren)
        // Compare the sprite of the bug part to the sprite in each object
        // If it's the same, turn it on. If not, turn it off.

        // Change sprites
        GameObject prevPart = childPartObjects[(int)newPart.slot];
        Parts.BugPart oldComponent = prevPart.GetComponent<Parts.BugPart>();
        // Remove old sprites
        List<Sprite> oldSprites;
        if (oldComponent.childrenSprites.Count() == 0)
        {
            oldSprites = new List<Sprite> { oldComponent.partSprite };
        } else
        {
            oldSprites = oldComponent.childrenSprites;
        }
        foreach (Sprite oldSprite in oldSprites)
        {
            currentSprites.Remove(oldSprite);
        }

        // Add new sprites:
        if (newPart.childrenSprites.Count() == 0)
        {
            currentSprites.Add(newPart.partSprite);
        } else
        {
            foreach (Sprite s in newPart.childrenSprites)
            {
                currentSprites.Add(s);
            }
        }

        // Turn on / off objects if we have them in sprites
        for (int childIdx = 0; childIdx < transform.childCount; childIdx++)
        {
            Transform child = transform.GetChild(childIdx);
            for (int grandchildIdx = 0; grandchildIdx < child.childCount; grandchildIdx++)
            {
                GameObject grandchild = child.GetChild(grandchildIdx).gameObject;
                SpriteRenderer grandchildRenderer = grandchild.GetComponent<SpriteRenderer>();
                if (grandchildRenderer != null)
                {
                    // Has renderer
                    bool matches = currentSprites.Contains(grandchildRenderer.sprite);
                    grandchild.SetActive(matches);
                }
            }
        }

        // Add new parts to logic
        // Remove old parts from logic
        Parts.BugPart previousPart = playerParts[(int)newPart.slot];
        if (previousPart != null)
        {
            RemoveEffect(previousPart.applyStats);
        }
        AddEffect(newPart.applyStats);
        playerParts[(int)newPart.slot] = newPart;
    }
}
