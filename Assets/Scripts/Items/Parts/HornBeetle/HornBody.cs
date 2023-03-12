using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HornBody : Parts.BugPart
{
    public override Parts.BugSlot slot => Parts.BugSlot.Body;

    public Sprite limbSprite;
    public override Sprite partSprite => limbSprite;

    public override int cost => 20;
    public override string itemName => "Horn Beetle Body";
    public override string description => "After taking damage, your health can't change for 1 second";

    private Nullable<int> parentRecordedHealth = null;
    private Nullable<int> myRecordedHealth = null;
    private DateTime lastChange = DateTime.Now;
    public float invulnerabilityLength = 1.0f;

    public override StatsController.Stats applyStats(StatsController.Stats initialStats)
    {
        // This function will *forceably* coerce the health to its original value if
        //   you take damage while invulnerable
        if (parentRecordedHealth.HasValue && initialStats._parentStats.health < parentRecordedHealth)
        {
            DateTime newTime = DateTime.Now;
            if ((newTime - lastChange).TotalSeconds <= invulnerabilityLength)
            {
                initialStats._parentStats.health = (int)parentRecordedHealth;
                initialStats.health = (int)myRecordedHealth;
            } else
            {
                lastChange = newTime;
            }
        }
        parentRecordedHealth = initialStats._parentStats.health;
        myRecordedHealth = initialStats.health;
        return initialStats;
    }
}
