using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class AbstractInteractiveObject : MonoBehaviour
{
    public List<string> interactiveTags = new List<string>();

    public float proximity = 1;

    protected abstract void ProximityBehavior(GameObject interactionObject);

    protected abstract void LonelyBehavior();

    public bool InProximity { get; set; } = true;

    public bool interactable = true;

    public abstract string InteractionText { get; }

    public void Update()
    {

        List<GameObject> objects = new List<GameObject>();
        foreach(var tag in interactiveTags)
        {
            objects.AddRange(GameObject.FindGameObjectsWithTag(tag));
        }

        InProximity = false;

        foreach (var subject in objects)
        {
            var distance = Vector3.Distance(subject.transform.position, transform.position);
            if (distance < proximity)
            {
                ProximityBehavior(subject);
                InProximity = true;

            }
        }
        if (!InProximity)
        {
            LonelyBehavior();
        }
    }
}
