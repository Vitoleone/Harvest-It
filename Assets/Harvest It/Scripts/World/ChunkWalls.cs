using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkWalls : MonoBehaviour
{
    [Header("Attributes")] 
    [SerializeField] private GameObject frontWall;
    [SerializeField] private GameObject rightWall;
    [SerializeField] private GameObject backWall;
    [SerializeField] private GameObject leftWall;

    public void Configure(int configuration)
    {
        if (isKthBitSet(configuration, 0))
            frontWall.SetActive(false);
        if (isKthBitSet(configuration, 1))
            rightWall.SetActive(false);
        if (isKthBitSet(configuration, 2))
            backWall.SetActive(false);
        if (isKthBitSet(configuration, 3))
            leftWall.SetActive(false);
    }

    public bool isKthBitSet(int configuration, int k)
    {
        if ((configuration & (1 << k)) > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
