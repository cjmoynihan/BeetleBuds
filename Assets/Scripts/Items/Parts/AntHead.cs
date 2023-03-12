using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class AntHead : Parts.BugPart
{
    public override Parts.BugSlot slot => Parts.BugSlot.Head;

    public Sprite limbSprite;

    public override Sprite partSprite => limbSprite;

    public override int cost => 1;

    public override string itemName => "Generic Ant head";

    public override string description => "Test Ant Description";

    public override StatsController.Stats applyStats(StatsController.Stats initialStats)
    {
        initialStats.health += 5;
        initialStats.maxHealth += 5;
        return initialStats;
    }
}
