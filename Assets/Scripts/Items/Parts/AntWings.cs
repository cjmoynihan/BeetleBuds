using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class AntWings : Parts.BugPart
{
    public override Parts.BugSlot slot => Parts.BugSlot.Wings;

    public Sprite limbSprite;

    public override Sprite partSprite => limbSprite;

    public override int cost => 1;

    public override string itemName => "A lack of wings";

    public override string description => "Sadly you don't have any wings";

    public override StatsController.Stats applyStats(StatsController.Stats initialStats)
    {
        
        return initialStats;
    }
}
