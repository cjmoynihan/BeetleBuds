using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

//public class LoadItems : MonoBehaviour 
//{
//    public TextAsset itemJson;

//    private List<Parts.BugPart> BugParts;

//    private void Start()
//    {
//        Items itemData = JsonUtility.FromJson<Items>(itemJson.text);
//        foreach(var item in itemData.items)
//        {
//            var part = new Parts.BugPart(item.slot, )
//        }

//    }


//}

[System.Serializable]
public class Items
{
    public List<ItemData> items = new List<ItemData>();
}

[System.Serializable]
public class ItemData
{
    public string partName;
    public Parts.BugSlot slot;
    public int cost;
    public List<Effect> effect = new List<Effect>();
}

[System.Serializable]
public class Effect
{
    public string name;
    public string desc;
}