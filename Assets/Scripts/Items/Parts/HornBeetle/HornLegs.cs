using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HornLegs : Parts.BugPart
{
    public override Parts.BugSlot slot => Parts.BugSlot.Legs;

    public Sprite limbSprite;
    public override Sprite partSprite => limbSprite;

    public override int cost => 20;
    public override string itemName => "Horn Beetle Legs";
    public override string description => "Don't slow down when attacking";

    public override StatsController.Stats applyStats(StatsController.Stats initialStats)
    {
        initialStats.slowDuration = 0;
        return initialStats;
    }
}
