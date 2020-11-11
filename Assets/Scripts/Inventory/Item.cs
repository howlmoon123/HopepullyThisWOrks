using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory Item", menuName ="Inventory/New Item")]
public class Item : ScriptableObject
{

    public InventoryItemType InventoryItemType = InventoryItemType.Weapon;
    public string itemName;
    public Sprite itemSprite;
    public string itemDescription;
    public float damage;
    public float defense;
    public float mana;
    public float encumberment;


    private void OnEnable()
    {
        
    }
}
