using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chomp : IHazard
{
    private float playerSpeedReduction;

    SpriteRenderer spriteRenderer;

    private float reduction = 0.5F;

    public Sprite closedMouth;

    public Sprite openMouth;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected  void Behavior(Collider2D collider)
    {
        var player = collider.gameObject.GetComponent<PlayerController>();
        var ps = player.playerSpeed;
        player.playerSpeed = ps * reduction;
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            spriteRenderer.sprite = closedMouth;
            Behavior(collider);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            spriteRenderer.sprite = openMouth;
            var player = collider.gameObject.GetComponent<PlayerController>();
            var ps = player.playerSpeed;
            player.playerSpeed = ps / reduction;
        }
    }

}
