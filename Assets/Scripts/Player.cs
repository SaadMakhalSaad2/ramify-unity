using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CollectablesInventory inventory;

    private void Awake()
    {
        inventory = new CollectablesInventory(12);
    }

    public void InstantiateItemToScene(Collectable item)
    {
        Vector2 playerLocation = transform.position;
        Vector2 spawnOffset = Random.insideUnitCircle * 1.25f;

        Collectable droppedItem = Instantiate(
            item,
            playerLocation + new Vector2(0, -2),
            Quaternion.identity
        );

        droppedItem.rb2d.AddForce(spawnOffset * 2f, ForceMode2D.Impulse);
    }
}
