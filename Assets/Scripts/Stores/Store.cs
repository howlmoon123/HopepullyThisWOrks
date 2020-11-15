using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    public InventoryLocations locations;
    public Inventory storeInventory;
    public int goldOnHand;

    public void SellItem(Item item)
    {
        if(storeInventory.HasItem(item))
        {

        }
    }
}
