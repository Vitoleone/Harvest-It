using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/CropData", fileName = "CropData")]
public class CropData : ScriptableObject
{
    [Header("Settings")] 
    public Crop cropPrefab;
    public InventoryItem.CropType cropType;
    public Sprite cropIcon;
}
