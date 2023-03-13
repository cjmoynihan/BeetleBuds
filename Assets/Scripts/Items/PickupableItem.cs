using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PickupableItem : AbstractInteractiveObject
{
    public GameObject interactiveE;

    private SpriteRenderer eSpriteRenderer;

    public Parts.BugPart item;

    private DateTime startPress;

    public float timeToBuy = 1;

    public bool isPurchased = false;

    public override string InteractionText
    {
        get
        {
            return "Pick up " + item.name + "?";
        }
    }


    public void SetItem(Parts.BugPart item)
    {
        this.item = item;
        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = item.GetComponent<Parts.BugPart>().partSprite;
        eSpriteRenderer = interactiveE.GetComponent<SpriteRenderer>();
        var itemRenderer = item.GetComponent<SpriteRenderer>();
    }

    protected override void LonelyBehavior()
    {
        if (!interactable) return;
        startPress = DateTime.Now;
        var color = eSpriteRenderer.color;
        eSpriteRenderer.color = new Color(color.r, color.g, color.b, 0);
    }

    protected override void ProximityBehavior(GameObject interactionObject)
    {
        if (!interactable) return;

        Color color = new Color();
        try
        {
            color = eSpriteRenderer.color;

        } catch
        {
            eSpriteRenderer = interactiveE.GetComponent<SpriteRenderer>();
        }

        TimeSpan pressTime = DateTime.Now - startPress;
        bool eIsPressed = Input.GetKey(KeyCode.E);
        if (pressTime.TotalSeconds > timeToBuy && eIsPressed)
        {
            var player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            player.AddParts(item);
            LonelyBehavior();
            Debug.Log(item.itemName + " Picked Up. " + item.description);
            Destroy(gameObject);
        }
        else if (eIsPressed)
        {
            float opacity = ((float)pressTime.TotalSeconds) / timeToBuy;
            eSpriteRenderer.color = new Color(color.r, color.g, color.b, opacity);
        }
        else if (!eIsPressed)
        {
            startPress = DateTime.Now;
            eSpriteRenderer.color = new Color(color.r, color.g, color.b, 0);
        }
    }
    private void Start()
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = item.GetComponent<Parts.BugPart>().partSprite;
    }
}
