using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class TestLimb : Parts.BugPart
{
    public override Parts.BugSlot slot => Parts.BugSlot.Eyes;

    public Sprite limbSprite;

    public override Sprite partSprite => limbSprite;

    public override int cost => 3;

    public override string itemName => "TEST EYES :)";

    public override string description => "TEST EYES DESCRIPTION!!";

    public override PlayerController.Stats applyStats(PlayerController.Stats initialStats)
    {
        initialStats.health += 1;
        return initialStats;
    }
}
