using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : AbstractInteractiveObject
{
    public override string InteractionText => throw new System.NotImplementedException();

    protected override void LonelyBehavior()
    {
        throw new System.NotImplementedException();
    }

    protected override void ProximityBehavior(GameObject interactionObject)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            var rotateSpeed = 10;
            if (player.transform.position.x > transform.position.x)
            {
                if (transform.eulerAngles.y > 0)
                {
                    transform.Rotate(0, -10, 0);

                }
            } else
            {
                if (transform.eulerAngles.y < 180)
                {
                    transform.Rotate(0, 10, 0);
                }
                
            }
        }
    }

}
