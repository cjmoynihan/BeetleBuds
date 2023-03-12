using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HornBeetleAI : EnemyTypes.EnemyBehavior
{
    public void Start()
    {

    }
    // Horn beetle moves slowly
    // Has "big" attack
    // Charging enemy
    private bool chargeReady = false;
    private bool charging = false;
    public float rotationSpeed = 80.0f;
    public float moveSpeed = 20f;
    public float chargeSpeed = 5000f;
    // The amount of degrees before it decides to charge
    public float chargeMargin = 2f;
    public float chargeBuildUp = 1f;
    public float recoilAmount = 0.1f;

    public override int SpawnValue => 4;

    public override void Behavior()
    {
        Transform playerTransform = FindPlayerTransform();
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (!chargeReady)
        {
            // Always moving forward slowly
            // Last attempt was just moving, instead applying forward velocity
            //transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, moveSpeed * Time.deltaTime);
            rb.AddForce(transform.up * moveSpeed * Time.deltaTime);

            // Calculate rotation difference
            float rotationAngle = (Mathf.Atan2(playerTransform.position.y - transform.position.y, playerTransform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;
            //Debug.Log(rotationAngle);
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, rotationAngle));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            if (System.Math.Abs((transform.rotation.eulerAngles - targetRotation.eulerAngles).z) <= chargeMargin)
            {
                rb.angularVelocity = 0;
                StartCoroutine(WaitChargeAttack());
                chargeReady = true;
            }

        } else
        {
            // Backup a bit
            if (!charging)
            {
                rb.AddForce(transform.up * -moveSpeed * 10 * Time.deltaTime);
            } else
            {
                rb.AddForce(transform.up * chargeSpeed * Time.deltaTime);
            }
        }
    }

    IEnumerator WaitChargeAttack()
    {
        yield return new WaitForSeconds(chargeBuildUp);
        charging = true;
    }

    private Vector2 RotateMinus90(Vector2 orig)
    {
        return new Vector2(-orig.y, orig.x);
    }

    //private void RotateSlowly()
    //{
    //    throw new System.NotImplementedException();
    //}

    protected override void PlayerCollision(Collision2D collision)
    {
        // Deal damage, knockback self, knockback player
        //throw new System.NotImplementedException();
        FindPlayer().GetComponent<PlayerController>().health -= 2;
    }

    protected override void AllCollision(Collision2D collision)
    {
        // Apply knockback and shake effect
        chargeReady = false;
        charging = false;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(rb.velocity.x * recoilAmount, rb.velocity.y * recoilAmount)
        //ContactPoint2D collisionPoint = collision.GetContact(0);
        //GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        //Knockback();
        ;
    }
    private void Knockback()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * -chargeSpeed);
    }
    private void Shake()
    {
        throw new System.NotImplementedException();
    }
}
