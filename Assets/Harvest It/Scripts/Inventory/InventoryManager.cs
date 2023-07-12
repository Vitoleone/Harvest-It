using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[RequireComponent(typeof(InventoryDisplay))]
public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    public Inventory inventory;
    private InventoryDisplay inventoryDisplay;
    public string dataPath;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        dataPath = Application.persistentDataPath + "/inventoryData.txt";
        inventory = new Inventory();
        CropTile.onCropHarvested += obj => CropHarvestedCallback(obj);
        LoadInventory();
        ConfigureInventoryDisplay();
    }

   

    private void OnDestroy()
    {
        CropTile.onCropHarvested -= obj => CropHarvestedCallback(obj);
    }

    private void ConfigureInventoryDisplay()
    {
        inventoryDisplay = GetComponent<InventoryDisplay>();
        inventoryDisplay.Configure(inventory);
    }
  
    private void CropHarvestedCallback(InventoryItem.CropType cropType)
    {
        inventory.CropHarvestedCallback(cropType);
        SaveInventory();
        inventoryDisplay.UpdateDisplay(inventory);
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

    [NaughtyAttributes.Button()]
    public void ClearInventory()
    {
        inventory.Clear();
        inventoryDisplay.UpdateDisplay(inventory);
        SaveInventory();
    }

    private void SaveInventory()
    {
        string data = JsonUtility.ToJson(inventory, true);
        File.WriteAllText(dataPath,data);
    }

    public Inventory GetInventory()
    {
        return inventory;
    }
}
