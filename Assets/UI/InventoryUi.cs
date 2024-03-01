using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUi : MonoBehaviour
{
    public GameObject inventoryPanel;
    public Player player;
    public List<SlotUi> slotUIs = new List<SlotUi>();

    void Start()
    {
        inventoryPanel.SetActive(false);
    }

    void Update()
    {
        SetupInventory();
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
        }
    }

    public void ToggleInventory()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
    }

    void SetupInventory()
    {
        if (slotUIs.Count == player.inventory.slots.Count)
        {
            for (int i = 0; i < slotUIs.Count; i++)
            {
                if (player.inventory.slots[i].type != CollectableType.NONE)
                {
                    slotUIs[i].SetItem(player.inventory.slots[i]);
                }
                else
                {
                    slotUIs[i].SetEmpty();
                }
            }
        }
    }

    public void Remove(int slotID)
    {
        Collectable itemToRemove = GameManager.instance.collectableManager.GetItemForType(
            player.inventory.slots[slotID].type
        );
        if (itemToRemove != null)
        {
            player.inventory.Remove(slotID);
            player.InstantiateItemToScene(itemToRemove);
        }
    }
}
