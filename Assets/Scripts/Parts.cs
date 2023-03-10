using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static PlayerController;

public class Parts
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

    // Bug Part is a StatEffect that also has a slot, cost, and other information
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
