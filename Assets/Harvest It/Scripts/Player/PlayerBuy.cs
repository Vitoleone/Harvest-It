using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBuy : MonoBehaviour
{
    public void BuyScythe(ScytheItemSectionDataHolder data)
    {
        if (CashManager.instance.coin - data.scytheData.price >= 0)
        {
            PlayerScytheController scytheController = PlayerScytheController.instance;

            data.scytheData.owned = true;
            CashManager.instance.UseCoins(data.scytheData.price);
            scytheController.ChangeCurrentScythe(data.scytheData);
            scytheController.onBuyedScythe?.Invoke(data);
        }
    }
    
}
