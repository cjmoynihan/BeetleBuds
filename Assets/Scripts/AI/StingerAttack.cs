using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StingerAttack : EnemyTypes.EnemyBehavior
{
    public int damage = 1;

    public override int SpawnValue => 5;

    protected override void PlayerCollision(Collision2D collision)
    {
        FindPlayer().GetComponent<PlayerController>().health -= damage;
    }
    protected override void AllCollision(Collision2D collision)
    {
        Destroy(gameObject);
    }
    public override void Behavior()
    {

    }
    private Vector2 RotateMinus90(Vector2 orig)
    {
        return new Vector2(-orig.y, orig.x);
    }
}
