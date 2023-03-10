using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chomp : IHazard
{
    
    SpriteRenderer spriteRenderer;
    public Sprite closedMouth;
    public Sprite openMouth;
    public static float reduction = 0.5F;

    public StatsController.Stats ChompEffect(StatsController.Stats initialStats)
    {
        initialStats.moveSpeed *= reduction;
        return initialStats;

    }

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            spriteRenderer.sprite = closedMouth;
            collider.gameObject.GetComponent<PlayerController>().AddEffect(ChompEffect);
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            spriteRenderer.sprite = openMouth;
            collider.gameObject.GetComponent<PlayerController>().RemoveEffect(ChompEffect);
        }
    }
}
