using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CropTile : MonoBehaviour
{
    public enum State
    {
        Empty,
        Seeded,
        Watered
    }

    [Header("Attributes")] 
    [SerializeField] private Transform cropParent;

    private State state;
    // Start is called before the first frame update
    void Start()
    {
        state = State.Empty;
    }
    

    public bool IsEmpty()
    {
        return state == State.Empty;
    }

    public void Seed(CropData cropData)
    {
        state = State.Seeded;
        Crop crop = Instantiate(cropData.cropPrefab, transform.position + Vector3.up*0.5f , quaternion.identity,cropParent);
        
    }
}
