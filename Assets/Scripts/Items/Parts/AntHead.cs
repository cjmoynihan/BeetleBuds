using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class AntHead : Parts.BugPart
{
    public override Parts.BugSlot slot => Parts.BugSlot.Eyes;

    public Sprite limbSprite;

    public override Sprite partSprite => limbSprite;

    public override int cost => 10;

    public override string itemName => "Generic Ant head";

    public override string description => "Test Ant Description";

    public override PlayerController.Stats applyStats(PlayerController.Stats initialStats)
    {
        initialStats.damage += 5;
        return initialStats;
    }
}
