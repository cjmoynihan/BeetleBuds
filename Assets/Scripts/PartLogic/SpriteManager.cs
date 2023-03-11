using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class SpriteManager : MonoBehaviour
{
    public List<SpriteRenderer> childSprites;

    public void replaceSprites(List<Sprite> newSprites)
    {
        for (int idx = 0; idx < childSprites.Count; idx++)
        {
            childSprites[idx].sprite = newSprites[idx];
        }
    }
    public void replaceSingleSprite(Sprite newSprite)
    {
        childSprites[0].sprite = newSprite;
    }
}
