using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Inventory inventory;
    public string dataPath;
    void Start()
    {
        dataPath = Application.dataPath + "/inventoryData.txt";
        inventory = new Inventory();
        CropTile.onCropHarvested += obj => CropHarvestedCallback(obj);
        LoadInventory();
    }

   

    private void OnDestroy()
    {
        CropTile.onCropHarvested -= obj => CropHarvestedCallback(obj);
    }

  
    private void CropHarvestedCallback(InventoryItem.CropType cropType)
    {
        inventory.CropHarvestedCallback(cropType);
        SaveInventory();
    }
    private void LoadInventory()
    {
        string data = "";
        if (File.Exists(dataPath))
        {
            data = File.ReadAllText(dataPath);
            inventory = JsonUtility.FromJson<Inventory>(data);
            if (inventory == null)
            {
                inventory = new Inventory();
            }
        }
        else
        {
            File.Create(dataPath);
            inventory = new Inventory();
        }
         
    }

    private void SaveInventory()
    {
        string data = JsonUtility.ToJson(inventory, true);
        File.WriteAllText(dataPath,data);
    }
}
