using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class AntMouth : Parts.BugPart
{
    public override Parts.BugSlot slot => Parts.BugSlot.Mouth;

    public Sprite limbSprite;

    public override Sprite partSprite => limbSprite;

    public override int cost => 1;

    public override string itemName => "Ant Mandibles";

    public override string description => "Great for eating crumbs";

    public override StatsController.Stats applyStats(StatsController.Stats initialStats)
    {
        initialStats.health += 5;
        initialStats.maxHealth += 5;
        return initialStats;
    }
}
