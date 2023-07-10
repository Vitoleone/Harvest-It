using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [Header("Attributes")] 
    [SerializeField] private GameObject chunkUnlockedElements;
    [SerializeField] private GameObject chunkLockedElements;
    [SerializeField] private TextMeshPro chunkPriceText;

    [Header("Settings")] 
    [SerializeField] private int initialPrice;
    private int currentPrice;
    private bool unlocked = false;

    [Header("Actions")] 
    public static  Action onUnlock;

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
}
