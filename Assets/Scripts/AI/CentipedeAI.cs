using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentipedeAI : EnemyTypes.EnemyBehavior
{
    public override int SpawnValue => 5;

    public override void Behavior()
    {
        throw new System.NotImplementedException();
    }

    protected override void PlayerCollision(Collision2D collision)
    {
        throw new System.NotImplementedException();
    }
}
