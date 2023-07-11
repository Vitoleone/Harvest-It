using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(ChunkWalls))]
public class Chunk : MonoBehaviour
{
    [Header("Attributes")] 
    [SerializeField] private GameObject chunkUnlockedElements;
    [SerializeField] private GameObject chunkLockedElements;
    [SerializeField] private TextMeshPro chunkPriceText;
    [SerializeField] private MeshFilter chunkFilter;
    private ChunkWalls chunkWalls;

    [Header("Settings")] 
    [SerializeField] private int initialPrice;
    private int currentPrice;
    private bool unlocked = false;

    [Header("Actions")] 
    public static  Action onUnlock;
    public static  Action onPriceChanged;

    private void Awake()
    {
        chunkWalls = GetComponent<ChunkWalls>();
    }

    private void Start()
    {
        currentPrice = initialPrice;
        chunkPriceText.text = currentPrice.ToString();
    }

    public void TryUnlock()
    {
        if(CashManager.instance.GetCoins() <= 0)
            return;
        currentPrice--;
        onPriceChanged?.Invoke();
        CashManager.instance.UseCoins(1);
        chunkPriceText.text = currentPrice.ToString();
        if (currentPrice <= 0)
        {
            Unlock();
        }
    }

    private void Unlock(bool triggerAction = true)
    {
        chunkUnlockedElements.SetActive(true);
        chunkLockedElements.SetActive(false);
        unlocked = true;
        if (triggerAction)
        {
            onUnlock?.Invoke();
        }
        
    }

    public bool IsUnlocked()
    {
        return unlocked;
    }
    public int GetInitialPrice()
    {
        return initialPrice;
    }
    public int GetCurrentPrice()
    {
        return currentPrice;
    }

    public void Initialize(int loadedPrice)
    {
        currentPrice = loadedPrice;
        chunkPriceText.text = currentPrice.ToString();
        if (currentPrice <= 0)
        {
            Unlock(false);
        }
    }

    public void UpdateWalls(int configuration)
    {
        chunkWalls.Configure(configuration);
    }

    public void DisplayUnlockedElements()
    {
        chunkLockedElements.SetActive(true);
    }

    public void SetRenderer(Mesh chunkShape)
    {
        chunkFilter.mesh = chunkShape;
    }
}
