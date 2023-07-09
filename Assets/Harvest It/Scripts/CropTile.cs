using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public enum TileFieldState
{
    Empty,
    Seeded,
    Watered
}
public class CropTile : MonoBehaviour
{
    [Header("Attributes")] 
    [SerializeField] private Transform cropParent;
    [SerializeField] private MeshRenderer TileRenderer;
    [SerializeField] private Color WateredColor;
    private CropData cropData;
    private Crop crop;
    [Header("Actions")] 
    public static Action<InventoryItem.CropType> onCropHarvested;

    private TileFieldState _tileFieldState;
    // Start is called before the first frame update
    void Start()
    {
        _tileFieldState = TileFieldState.Empty;
    }
    

    public bool IsEmpty()
    {
        return _tileFieldState == TileFieldState.Empty;
    }
    public bool IsSeeded()
    {
        return _tileFieldState == TileFieldState.Seeded;
    }
    public void Water()
    {
        _tileFieldState = TileFieldState.Watered;
        TileRenderer.gameObject.LeanColor(WateredColor, 1).setEase(LeanTweenType.easeOutBack);
        crop.Grown();
    }

    public void Seed(CropData cropData)
    {
        _tileFieldState = TileFieldState.Seeded;
        crop = Instantiate(cropData.cropPrefab, transform.position + Vector3.up*0.5f , quaternion.identity);
        this.cropData = cropData;
    }


    public void Harvest()
    {
        _tileFieldState = TileFieldState.Empty;
        crop.Harvested();
        TileRenderer.material.color = Color.white;
        onCropHarvested?.Invoke(cropData.cropType);
    }
}
