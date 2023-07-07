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

    public void Seed(CropData cropData)
    {
        _tileFieldState = TileFieldState.Seeded;
        Crop crop = Instantiate(cropData.cropPrefab, transform.position + Vector3.up*0.5f , quaternion.identity,cropParent);
        
    }
}
