using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerShopInteract : MonoBehaviour
{
  private void OnTriggerEnter(Collider other)
  {
    if (other.TryGetComponent(out BuyCircleZoneTag shop))
    {
      if (shop.type == BuyCircleZoneTag.ShopType.Scythe)
        OpenScytheShop();
      else if (shop.type == BuyCircleZoneTag.ShopType.Worker)
        OpenWorkerShop();

    }
  }
  private void OnTriggerExit(Collider other)
  {
    if (other.TryGetComponent(out BuyCircleZoneTag shop))
    {
      if (shop.type == BuyCircleZoneTag.ShopType.Scythe)
        CloseScytheShop();
      else if (shop.type == BuyCircleZoneTag.ShopType.Worker)
        CloseWorkerShop();

    }
  }
  private void CloseScytheShop()
  {
    UIController.instance.CloseShopPanel();
  }

  private void OpenScytheShop()
  {
    UIController.instance.OpenShopPanel();
  }
  private void OpenWorkerShop()
  {
    throw new NotImplementedException();
  }
  private void CloseWorkerShop()
  {
    throw new NotImplementedException();
  }
}

  
