using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CollectablesInventory
{
    [System.Serializable]
    public class Slot
    {
        public int itemsCount;
        public int maxAllowed;
        public CollectableType type;
        public Sprite icon;

        public Slot()
        {
            type = CollectableType.NONE;
            itemsCount = 0;
            maxAllowed = 2;
        }

        public bool CanAddItem()
        {
            if (itemsCount < maxAllowed)
            {
                return true;
            }
            return false;
        }

        public void AddItem(Collectable item)
        {
            this.type = item.type;
            this.itemsCount++;
            this.icon = item.icon;
        }

        public void RemoveItem()
        {
            if (itemsCount > 0)
            {
                itemsCount--;
                if(itemsCount ==0 )
                {
                  this.icon = null;
                  this.type = CollectableType.NONE;
                }
            }
        }
    }

    public List<Slot> slots = new List<Slot>();

    public CollectablesInventory(int slotsCount)
    {
        for (int i = 0; i < slotsCount; i++)
        {
            Slot slot = new Slot();
            slots.Add(slot);
        }
    }

    public void Add(Collectable item)
    {
        //if item already added at least once before
        foreach (Slot slot in slots)
        {
            if (slot.type == item.type && slot.CanAddItem())
            {
                slot.AddItem(item);
                return;
            }
        }
        //if item was never added before, add it to first available slot
        foreach (Slot slot in slots)
        {
            if (slot.type == CollectableType.NONE)
            {
                slot.AddItem(item);
                return;
            }
        }
    }

    public void Remove(int itemIndex) { 
      slots[itemIndex].RemoveItem();
    }
}
