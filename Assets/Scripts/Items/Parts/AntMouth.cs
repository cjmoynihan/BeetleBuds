using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class AntEyes : Parts.BugPart
{
    public override Parts.BugSlot slot => Parts.BugSlot.Eyes;

    public Sprite limbSprite;

    public override Sprite partSprite => limbSprite;

    public override int cost => 1;

    public override string itemName => "Ant Eyes";

    public override string description => "Just a pair of eyes";

    public override StatsController.Stats applyStats(StatsController.Stats initialStats)
    {
        initialStats.health += 5;
        return initialStats;
    }
}
