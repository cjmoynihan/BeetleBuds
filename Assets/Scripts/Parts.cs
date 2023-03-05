using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerController;

public class Parts : MonoBehaviour
{
    public enum bugSlot
    {
        Eyes,
        Mouth,
        Antennae,
        Legs,
        Wings,
        Body,
        Tail
    }

    public abstract class BugPart
    {
        private bugSlot thisSlot;

        public BugPart(bugSlot slot)
        {
            bugSlot thisSlot = slot;
        }
        public abstract Stats applyStats(Stats initialStats);
    }
}
