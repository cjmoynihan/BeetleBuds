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

        public List<Sprite> childrenSprites;

        public SpriteRenderer[] GetSpriteRenderers()
        {
            return GetComponentsInChildren<SpriteRenderer>();
        }

        public void ReplaceSprites()
        {
            SpriteRenderer[] childRenderers = GetSpriteRenderers();
            if (childrenSprites.Count == 0)
            {
                if(childRenderers.Length != 1)
                {
                    throw new ArgumentException("There aren't enough sprites to fill these limbs!");
                }
                childRenderers[0].sprite = partSprite;
            } else
            {
                if(childRenderers.Length != childrenSprites.Count)
                {
                    throw new ArgumentException("There aren't enough sprites to fill these limbs!");
                }
                for (int idx = 0; idx < childrenSprites.Count; idx++)
                {
                    childRenderers[idx].sprite = childrenSprites[idx];
                }
            }
        }

        public void _replaceSprites(List<Sprite> newSprites)
        {
            SpriteRenderer[] childSprites = GetSpriteRenderers();
            for (int idx = 0; idx < childrenSprites.Count; idx++)
            {
                childSprites[idx].sprite = newSprites[idx];
            }
        }
        public void _replaceSingleSprite(Sprite newSprite)
        {
            SpriteRenderer[] childSprites = GetSpriteRenderers();
            childSprites[0].sprite = newSprite;
        }

        public abstract int cost { get; }

        public abstract StatsController.Stats applyStats(StatsController.Stats initialStats);
    }
}
