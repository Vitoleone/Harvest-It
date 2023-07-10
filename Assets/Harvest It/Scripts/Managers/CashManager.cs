using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CashManager : MonoBehaviour
{
    public static CashManager instance;
    [Header("Attributes")] 
    private int coin;
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

    public void AddCoins( int earning)
    {
        coin += earning;
        SaveData();
        UpdateCoinContainer();
    }
}
