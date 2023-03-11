using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts
{
    public enum BugSlot
    {
        Body,
        Booty,
        Eyes,
        Head,
        Legs,
        Mouth,
        Wings
    }

    // Bug Part is a StatEffect that also has a slot, cost, and other information
    public abstract class BugPart : MonoBehaviour
    {
        public abstract string itemName { get; }

        public abstract string description { get;}

        public abstract BugSlot slot { get; }

        public abstract Sprite partSprite { get; }

        public abstract int cost { get; }

        public abstract StatsController.Stats applyStats(StatsController.Stats initialStats);
    }
}
