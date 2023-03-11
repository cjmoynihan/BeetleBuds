using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts : MonoBehaviour
{
    
    public enum BugSlot
    {
        Eyes,
        Mouth,
        Antennae,
        Legs,
        Wings,
        Body,
        Tail
    }

    public abstract class BugPart : MonoBehaviour
    {
        public abstract string itemName { get; }

        public abstract string description { get;}

        public abstract BugSlot slot { get;  }

        public abstract Sprite partSprite { get; }

        public abstract int cost { get; }

        public abstract StatsController.Stats applyStats(StatsController.Stats initialStats);
    }
}
