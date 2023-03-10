using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    public GameObject ShopTextObject;

    private TMP_Text _shopText;

    private List<AbstractInteractiveObject> _interactiveObjects;

    public List<Parts.BugPart> BuyableParts;

    private void Start()
    {
        _interactiveObjects = GameObject.FindGameObjectsWithTag("InteractiveObject").Select(x=>x.GetComponent<AbstractInteractiveObject>()).ToList();
        _shopText = ShopTextObject.GetComponent<TMP_Text>();

        foreach(var obj in _interactiveObjects)
        {
            var itemSeller = obj.GetComponent<BuyableItem>();
            if (itemSeller != null)
            {
                var itemIndex = Random.Range(0, BuyableParts.Count());
                itemSeller.SetItem(BuyableParts[itemIndex]);
            }
        }
    }

    public void Update()
    {
        if (_interactiveObjects.Any(x=>!x.interactable))
        {
            _interactiveObjects.ForEach(x => x.interactable = false);
        }

        bool itemInProximity = false;
        foreach (var interactiveObject in _interactiveObjects)
        {
            if (interactiveObject.InProximity)
            {
                _shopText.text = interactiveObject.InteractionText;
                itemInProximity = true;
            }
        }
        if (!itemInProximity)
        {
            _shopText.text = "";
        }
    }
}
