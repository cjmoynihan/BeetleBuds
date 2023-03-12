using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HornMouth : Parts.BugPart
{
    public override Parts.BugSlot slot => Parts.BugSlot.Mouth;

    public Sprite limbSprite;
    public override Sprite partSprite => limbSprite;

    public override int cost => 20;
    public override string itemName => "Horn Beetle Horn";
    public override string description => "Slow but strong";

    public override StatsController.Stats applyStats(StatsController.Stats initialStats)
    {
        initialStats.attackDamage *= 2;
        initialStats.attackRange *= 2;
        initialStats.attackSpeed *= 2;  // Negative effect
        return initialStats;
    }
}
