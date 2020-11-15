using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName ="new Inventory", menuName ="Inventory/Inventory")]
public class Inventory :  ScriptableObject
{
    public InventoryLocations Locations = InventoryLocations.Player;
    public List<Item> inventory;
  


    public bool HasItem(Item item)
    {
       
        return inventory.Find(x => x == item).qty > 0 ? true : false;
   
    }

    public bool HasItem(string code)
    {
       
        return inventory.Find(x => x.itemId == code).qty > 0 ? true : false;
    }

    public Item GetItem(Item item)
    {
        return inventory.Find(x => x == item);
    }

    public Item GetItem(string id)
    {
        return inventory.Find(x => x.itemId == id);
    }

    public bool RemoveItem(Item item)
    {
        if (HasItem(item))
        {
            Item it = GetItem(item);
            if( it.qty > 0)
            {
                it.qty--;
                return true;
            }
            else
            {
                return false;
            }
        }else
        {
            return false;
        }
    }

    public bool RemoveItem(string id)
    {
        if (HasItem(id))
        {
            Item it = GetItem(id);
            if (it.qty > 0)
            {
                it.qty--;
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public void AddItem(Item item)
    {
        Item it = GetItem(item);
        it.qty++;
    }

    public void AddItem(string id)
    {
        Item it = GetItem(id);
        it.qty++;
    }

    
}
