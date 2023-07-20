using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CashManager : MonoBehaviour
{
    public static CashManager instance;
    [Header("Attributes")] 
    public int coin;
    private TextMeshProUGUI coinAmount;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }
        LoadData();
    }

    void UpdateCoinContainer()
    {
        GameObject goldAmountText = GameObject.FindGameObjectWithTag("GoldAmount");
        goldAmountText.GetComponent<TextMeshProUGUI>().text = coin.ToString();
    }
    public void LoadData()
    {
        coin = PlayerPrefs.GetInt("Coin");
        UpdateCoinContainer();
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("Coin",coin);
    }

    [NaughtyAttributes.Button()]
    public void Add500CoinsToPlayer()
    {
        AddCoins(500);
    }

    public void AddCoins( int earning)
    {
        coin += earning;
        SaveData();
        UpdateCoinContainer();
    }

    public void UseCoins(int amount)
    {
        AddCoins(-amount);
    }

    public int GetCoins()
    {
        return coin;
    }
}
