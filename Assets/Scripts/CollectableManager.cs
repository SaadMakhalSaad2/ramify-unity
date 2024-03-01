using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollectableManager : MonoBehaviour
{
    public Collectable[] collectables;
    private Dictionary<CollectableType, Collectable> itemsDb =
        new Dictionary<CollectableType, Collectable>();

    private void Awake()
    {
        foreach (Collectable item in collectables)
        {
            AddItem(item);
        }
    }

    private void AddItem(Collectable item)
    {
        if (!itemsDb.ContainsKey(item.type))
        {
            itemsDb.Add(item.type, item);
        }
    }

    private int GetItemsCount()
    {
        return itemsDb.Count;
    }

    public Collectable GetItemForType(CollectableType type)
    {
        if (itemsDb.ContainsKey(type))
        {
            return itemsDb[type];
        }
        return null;
    }
}
