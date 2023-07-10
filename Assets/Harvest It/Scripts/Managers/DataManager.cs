using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    DataManager()
    {
        instance = this;
    }
    [SerializeField] private CropData[] allCropData;

    public Sprite GetSpriteFromCropType(InventoryItem.CropType cropType)
    {
        for (int i = 0; i < allCropData.Length; i++)
        {
            if (allCropData[i].cropType == cropType)
            {
                return allCropData[i].cropIcon;
            }
        }
        Debug.LogError("No cropType found of that type");
        return null;
    }

    public int GetEarningFromCropType(InventoryItem.CropType cropType)
    {
        for (int i = 0; i < allCropData.Length; i++)
        {
            if (allCropData[i].cropType == cropType)
            {
                return allCropData[i].price;
            }
        }
        Debug.LogError("No cropType found of that type");
        return 0;
    }
}
