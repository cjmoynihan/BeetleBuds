using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.Port;

public class BuyableItem : AbstractInteractiveObject
{
    public GameObject interactiveE;

    private SpriteRenderer eSpriteRenderer;

    public Parts.BugPart item;

    private DateTime startPress;

    public float timeToBuy = 1;

    public bool isPurchased = false;

    public override string InteractionText { get {
            if (isPurchased) 
            {
                return "Sold!";
            }
            else if (interactable) 
            {
                return "Hold [E] To Purchase";
            }
            else
            {
                return "Sold Out";
            }}}


    public void SetItem(Parts.BugPart item)
    {
        this.item = item;
        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = item.GetComponent<Parts.BugPart>().partSprite;
        eSpriteRenderer = interactiveE.GetComponent<SpriteRenderer>();
        var itemRenderer = item.GetComponent<SpriteRenderer>();
        gameObject.GetComponentsInChildren<TMP_Text>().First(x => x.name == "Cost").text = item.cost.ToString();
        gameObject.GetComponentsInChildren<TMP_Text>().First(x => x.name == "Name").text = item.itemName.ToString();
    }

    protected override void LonelyBehavior()
    {
        if (!interactable) return;
        startPress = DateTime.Now;
        eSpriteRenderer.GetComponent<SpriteRenderer>();
        var color = eSpriteRenderer.color;
        eSpriteRenderer.color = new Color(color.r, color.g, color.b, 0);
    }

    protected override void ProximityBehavior(GameObject interactionObject)
    {
        if (!interactable) return;

        TimeSpan pressTime = DateTime.Now - startPress;
        var color = eSpriteRenderer.color;
        bool eIsPressed = Input.GetKey(KeyCode.E);
        if (pressTime.TotalSeconds > timeToBuy && eIsPressed)
        {
            var player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            player.AddParts(item);
            isPurchased = true;
            LonelyBehavior();
            interactable = false;
            Debug.Log("Item Purchased");
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
}
