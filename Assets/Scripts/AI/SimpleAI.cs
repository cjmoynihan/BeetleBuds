using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAI : EnemyTypes.EnemyBehavior
{
    public float speed = 0.8f;

    public override int SpawnValue => 1;

    protected override void PlayerCollision(Collision2D collision)
    {
        FindPlayer().GetComponent<PlayerController>().health -= 1;
    }
    public override void Behavior()
    {
        transform.right = RotateMinus90(FindPlayerTransform().position - transform.position);
        transform.position = Vector2.MoveTowards(transform.position, FindPlayerTransform().position, speed * Time.deltaTime);
    }
    private Vector2 RotateMinus90(Vector2 orig)
    {
        return new Vector2(-orig.y, orig.x);
    }
}
