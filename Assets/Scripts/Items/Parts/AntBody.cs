using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class AntBody : Parts.BugPart
{
    public override Parts.BugSlot slot => Parts.BugSlot.Body;

    public Sprite limbSprite;

    public override Sprite partSprite => limbSprite;

    public override int cost => 1;

    public override string itemName => "Ant Body";

    public override string description => "An ant body";

    public override StatsController.Stats applyStats(StatsController.Stats initialStats)
    {
        initialStats.health += 5;
        initialStats.maxHealth += 5;
        return initialStats;
    }
}
