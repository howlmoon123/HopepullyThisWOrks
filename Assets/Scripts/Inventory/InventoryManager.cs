using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class InventoryManager : SingletonMonobehaviour<InventoryManager>
{
    public List<Inventory> inventories = new List<Inventory>();
    public Dictionary<InventoryLocations, Inventory> inventoryDictionary;
   
    private void Start()
    {
       
    }

    
}
