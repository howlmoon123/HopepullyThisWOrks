using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu(fileName = "Inventory Item", menuName ="Inventory/New Item")]
public class Item : ScriptableObject, IPointerEnterHandler
{
    public string itemId;
    public InventoryItemType InventoryItemType = InventoryItemType.Weapon;
    public string itemName;
    public Sprite itemSprite;
    public string itemDescription;
    public float damage;
    public float defense;
    public float mana;
    public float encumberment;
    public int qty;
    public int buyValue;
    public int sellValue;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Item name " + itemDescription);
    }

    /// <summary>
    /// What is needed during setup
    /// </summary>
    private void OnEnable()
    {
        if (!Application.isPlaying)
        {
            if(itemId == "")
            {
                itemId = Guid.NewGuid().ToString();
            }else
            {
                return;
            }
        }
        
    }
}
