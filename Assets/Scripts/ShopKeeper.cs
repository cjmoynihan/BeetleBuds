using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : AbstractInteractiveObject
{
    public override string InteractionText { get { 
            if (interactable) return $"Hey... You look like you could use a little blood. Interested? [ [E] to Heal {healFactor}hp]";
            else return "Sorry, all out :("; } }

    public GameObject interactiveE;
    public int rotateSpeed = 7;
    public GameObject DoctorMosq;
    private DateTime startPress;
    public float timeToBuy = 1;
    public float PopInSpeed = 0.1f;
    public int healFactor = 50;
    private SpriteRenderer eSpriteRenderer;

    protected override void LonelyBehavior()
    {
        if (DoctorMosq.transform.position.y > -13)
        {
            DoctorMosq.transform.SetPositionAndRotation(new Vector3(DoctorMosq.transform.position.x, DoctorMosq.transform.position.y - PopInSpeed), DoctorMosq.transform.rotation);
        }
        var color = eSpriteRenderer.color;
        eSpriteRenderer.color = new Color(color.r, color.g, color.b, 0);
    }

    protected override void ProximityBehavior(GameObject interactionObject)
    {
        if (DoctorMosq.transform.position.y < -1.6 && interactable)
        {
            DoctorMosq.transform.SetPositionAndRotation(new Vector3(DoctorMosq.transform.position.x, DoctorMosq.transform.position.y + PopInSpeed), DoctorMosq.transform.rotation);
        }
        if (!interactable) return;

        TimeSpan pressTime = DateTime.Now - startPress;
        var color = eSpriteRenderer.color;
        bool eIsPressed = Input.GetKey(KeyCode.E);
        if (pressTime.TotalSeconds > timeToBuy && eIsPressed)
        {
            var playerCon = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            playerCon.health += healFactor;
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

    // Start is called before the first frame update
    void Start()
    {
        eSpriteRenderer = interactiveE.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var player = GameObject.FindGameObjectWithTag("Player");



        if (player != null)
        {
            if (player.transform.position.x > transform.position.x)
            {
                if (transform.eulerAngles.y > 0)
                {
                    transform.Rotate(0, -rotateSpeed, 0);

                }
            } else
            {
                if (transform.eulerAngles.y < 180)
                {
                    transform.Rotate(0, rotateSpeed, 0);
                }
                
            }
        }
    }

}
