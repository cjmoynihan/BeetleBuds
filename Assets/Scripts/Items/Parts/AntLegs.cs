using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class AntLegs : Parts.BugPart
{
    public override Parts.BugSlot slot => Parts.BugSlot.Eyes;

    public Sprite limbSprite;

    public override Sprite partSprite => limbSprite;

    public override int cost => 1;

    public override string itemName => "Ant Legs";

    public override string description => "6 legs are made for walking";

    public override StatsController.Stats applyStats(StatsController.Stats initialStats)
    {
        initialStats.health += 5;
        return initialStats;
    }
}
