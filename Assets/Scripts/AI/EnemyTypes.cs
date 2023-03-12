using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTypes
{

    // Enemy needs:
    //  Behavior -> How does it move, rotate?
    //  Attack -> How does it deal damage (could incorporate into behavior)
    //  Health
    //  Other properties -> Splitting, dealing damage to itself, etc
    public abstract class EnemyBehavior : MonoBehaviour
    {
        public abstract int SpawnValue { get; }
        public int hitPoints = 1;
        private PlayerController playerController;
        // Applies in place, modifying the enemy object directly
        public abstract void Behavior();

        protected virtual void Start()
        {
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }

        protected void AttackCollision(Collision2D collision)
        {
            hitPoints -= Mathf.CeilToInt(playerController.ModifiedStats.attackDamage);
            if (hitPoints <= 0)
            {
                Destroy(gameObject);
            }
        }
        protected abstract void PlayerCollision(Collision2D collision);

        protected virtual void AllCollision(Collision2D collision) { }

        protected void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Attack")
            {
                AttackCollision(collision);
            }
            if (collision.gameObject.tag == "Player")
            {
                PlayerCollision(collision);
            }
            AllCollision(collision);
        }
        public void FixedUpdate()
        {
            Behavior();
        }
        protected GameObject FindPlayer()
        {
            return GameObject.FindWithTag("Player");
        }

        protected Transform FindPlayerTransform()
        {
            return FindPlayer().transform;   
        }
        protected float DistToPlayer()
        {
            return Vector2.Distance(FindPlayer().transform.position, transform.position);
        }
    }


    //public class SimpleAI : EnemyBehavior
    //{
    //    protected override void PlayerCollision(Collision2D collision)
    //    {
    //        FindPlayer().GetComponent<PlayerController>().health -= 1;
    //    }
    //    public override void Behavior()
    //    {
    //        transform.LookAt(FindPlayerTransform());
    //    }
    //}
}
