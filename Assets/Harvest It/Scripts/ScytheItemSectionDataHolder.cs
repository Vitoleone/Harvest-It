using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScytheItemSectionDataHolder : MonoBehaviour
{
  [Header("Elements")] 
  [SerializeField] public Button button;
  [SerializeField] public TextMeshProUGUI priceText;
  [SerializeField] public ScytheData scytheData;

  private void Start()
  {
    PlayerScytheController.instance.onBuyedScythe += ItemSold;
    if (scytheData.owned)
    {
      button.gameObject.SetActive(false);
    }
    priceText.text = scytheData.price.ToString()+"$";
  }

  private void OnDestroy()
  {
    PlayerScytheController.instance.onBuyedScythe -= ItemSold;
  }

  public void ItemSold(ScytheItemSectionDataHolder data)
  {
    data.button.gameObject.SetActive(false);
  }
}
