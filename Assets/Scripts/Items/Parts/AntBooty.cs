using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class AntBooty : Parts.BugPart
{
    public override Parts.BugSlot slot => Parts.BugSlot.Booty;

    public Sprite limbSprite;

    public override Sprite partSprite => limbSprite;

    public override int cost => 1;

    public override string itemName => "Ant Booty";

    public override string description => "The biggest part of the ant";

    public override StatsController.Stats applyStats(StatsController.Stats initialStats)
    {
        initialStats.health += 5;
        initialStats.maxHealth += 5;
        return initialStats;
    }
}
