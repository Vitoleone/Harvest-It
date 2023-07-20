using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIController : MonoBehaviour
{
    [Header("Elements")]
    public static UIController instance;

    [Header("UI Elements")] 
    [SerializeField] private GameObject ShopPanel;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            return;
    }

    public void OpenShopPanel()
    {
        ShopPanel.SetActive(true);
    }
    public void CloseShopPanel()
    {
        ShopPanel.SetActive(false);
    }
    
    
}
