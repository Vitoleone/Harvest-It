using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuyerInteract : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out SellCircleZoneTag circleZoneTag))
        {
            SellCrops();
        }
    }

    private void SellCrops()
    {
        Inventory inventory = InventoryManager.instance.GetInventory();
        InventoryItem[] items = inventory.GetInventoryItems();
        int earning = 0;

        for (int i = 0; i < items.Length; i++)
        {
            int itemPrice = DataManager.instance.GetEarningFromCropType(items[i].cropType);

            earning += itemPrice * items[i].amount;
        }

        CashManager.instance.AddCoins(earning);
        InventoryManager.instance.ClearInventory();
    }

    
}
