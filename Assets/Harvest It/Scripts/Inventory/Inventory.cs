using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
   [SerializeField] private List<InventoryItem> items = new List<InventoryItem>();

   public void CropHarvestedCallback(InventoryItem.CropType cropType)
   {
      bool cropFound = false;
      for (int i = 0; i < items.Count; i++)
      {
         InventoryItem item = items[i];
         if (item.cropType == cropType)
         {
            cropFound = true;
            item.amount++;
            break;
         }
      }

      if (cropFound)
      {
         return;
      }
      items.Add(new InventoryItem(cropType,1));

   }
}
