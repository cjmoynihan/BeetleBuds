using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class QueenBeeController : EnemyTypes.EnemyBehavior
{

    public enum AttackState
    {
        MovingAndShooting
    }

    public float rotationSpeed = 80f;
    public float ticker = 0f;
    public float tickerSpeed = 0.1f;

    // Movement Control
    public float tangentForce = 500f;
    public float moveSpeed = 100f;
    public float minDistance = 3f;
    public float backupModifier = 4f;

    // Attack Control
    private bool canAttack = true;
    private float attackCooldown = 0.1f;
    public float slowAttackCooldown = 0.5f;
    public float fastAttackCooldown = 0.2f;
    public float spread = 0.5f;
    public GameObject stingerObject;
    public float attackVelocity = 1;
    public float attackPositionBuffer = 0.15f;



    public GameObject player;

    private AttackState attackState= AttackState.MovingAndShooting;

    public override int SpawnValue => 15;

    protected override void PlayerCollision(Collision2D collision)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    public override void Behavior()
    {
        switch (attackState)
        {
            case AttackState.MovingAndShooting:
                MovingAndShooting();
                break;
        }
    }

    void MoveTowardsPlayer()
    {
        var player  = GameObject.FindGameObjectWithTag("Player");
        var playerPosition = player.transform.position;
        var playerDistance = (playerPosition - transform.position).magnitude;
        var forceModifier = playerDistance > minDistance ? 1 : -backupModifier;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        var sideForce = Mathf.Sin(ticker);
        ticker += tickerSpeed;

        rb.AddForce(forceModifier*transform.up * moveSpeed * Time.deltaTime);
        rb.AddForce(sideForce * transform.right * tangentForce * Time.deltaTime);

    }

    void RotateTowardsPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        var playerTransform = player.transform;

        // Calculate rotation difference
        float rotationAngle = (Mathf.Atan2(playerTransform.position.y - transform.position.y, playerTransform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;

        //Debug.Log(rotationAngle);
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, rotationAngle));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
    void MovingAndShooting()
    {
        attackCooldown = slowAttackCooldown;
        RotateTowardsPlayer();
        MoveTowardsPlayer();
        Shoot();
    }


    // Update is called once per frame
    void Shoot()
    {
        var playerPosition = FindPlayerTransform().position;
        var accuracy = Random.Range(-spread, spread);
        if (playerPosition != null && canAttack)
        {
            Vector3 attackDirection = (Vector3)playerPosition - transform.position;
            attackDirection += new Vector3(accuracy, accuracy) * attackDirection.magnitude;
            // Not sure why the rotation doesn't work? Should be the last variable in Instantiate
            GameObject newStinger = Instantiate(stingerObject, transform.position + attackDirection * attackPositionBuffer, Quaternion.Euler(attackDirection));
            Debug.Log(Quaternion.Euler(attackDirection));
            Rigidbody2D stingerRB = newStinger.GetComponent<Rigidbody2D>();
            stingerRB.velocity = attackDirection * attackVelocity;
            canAttack = false;
            StartCoroutine(WaitAfterShot());
        }
    }
    IEnumerator WaitAfterShot()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
}
