using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeAI : EnemyTypes.EnemyBehavior
{
    public float attackCooldown = 2;
    private bool canAttack = true;
    public GameObject stingerObject;
    public float attackVelocity = 1;
    public float attackPositionBuffer = 0.15f;

    public override void Behavior()
    {
        // Happens every FixedUpdate. Used for attacking, etc
        // Bee enemy attacks with a ranged attack every attack cooldown

        // TODO: Find enemy
        // TODO: If enemy is there?
        // TODO: Make regular attack

        Vector3? playerPosition = LineOfSight();
        // TODO: Fix player targeting mechanism
        playerPosition = FindPlayerTransform().position;
        if(playerPosition != null && canAttack)
        {
            Vector3 attackDirection = (Vector3)playerPosition - transform.position;
            // Not sure why the rotation doesn't work? Should be the last variable in Instantiate
            GameObject newStinger = Instantiate(stingerObject, transform.position + attackDirection * attackPositionBuffer, Quaternion.Euler(attackDirection));
            Debug.Log(Quaternion.Euler(attackDirection));
            Rigidbody2D stingerRB = newStinger.GetComponent<Rigidbody2D>();
            stingerRB.velocity = attackDirection * attackVelocity;
            canAttack = false;
            StartCoroutine(WaitAfterShot());

        }

    }

    private Vector3? LineOfSight()
    {
        Transform pt = FindPlayerTransform();
        var rayDirection = pt.position - transform.position;
        RaycastHit hit;
        // Do I want to only check on a certain layer??
        if (Physics.Raycast(transform.position, rayDirection, out hit, Vector3.Distance(pt.position, transform.position)))
        {
            return(pt.position);
        }
        return null;
    }

    IEnumerator WaitAfterShot()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }


    protected override void PlayerCollision(Collision2D collision)
    {
        throw new System.NotImplementedException();
    }
}
