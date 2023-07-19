using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerAnimator))]
[RequireComponent(typeof(PlayerToolSelector))]
public class PlayerHarvestAbility : MonoBehaviour
{
   [Header("Attributes")] 
   [SerializeField] private Transform harvestSphere;
   private PlayerAnimator playerAnimator;
   private PlayerToolSelector playerToolSelector;
   private IEnumerator coroutine;
   [Header("Settings")] 
   private CropField currentCropField;
   private bool canHarvest;

   private void Start()
   {
      playerAnimator = GetComponent<PlayerAnimator>();
      playerToolSelector = GetComponent<PlayerToolSelector>();
      CropField.onFullyHarvested += CropFieldOnFullyHarvested;
      playerToolSelector.onToolSelected += ToolSelectedCallBack;
   }



   private void OnDestroy()
   {
      CropField.onFullyHarvested -= CropFieldOnFullyHarvested;
      playerToolSelector.onToolSelected -= ToolSelectedCallBack;
   }

   private void CropFieldOnFullyHarvested(CropField cropField)
   {
      if (cropField == currentCropField)
         playerAnimator.StopHarvestingAnimation();
   }

   private void ToolSelectedCallBack(PlayerToolSelector.Tool selectedTool)
   {
      if (!playerToolSelector.CanHarvest())
         playerAnimator.StopHarvestingAnimation();
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.TryGetComponent(out CropField cropField))
      {
         if (cropField.IsWatered())
         {
            currentCropField = cropField;
            EnteredCropField(currentCropField);
         }
      }
   }

   private void EnteredCropField(CropField cropField)
   {
      if (playerToolSelector.CanHarvest())
      {
         if (currentCropField == null)
         {
            currentCropField = cropField;
         }
         playerAnimator.PlayHarvestingAnimation();
         if (cropField.cropFieldHealth <= 0)
         {
            if (canHarvest)
               currentCropField.Harvest(harvestSphere);
         }
         else
         {
            coroutine = DamageCoroutine(1,currentCropField);
            StartCoroutine(coroutine);

         }
      }
   }

   IEnumerator DamageCoroutine(int damage,CropField currentCropField)
   {
      yield return new WaitForSeconds(1);
      currentCropField.TakeDamage(damage);
      StopAllCoroutines();
   }

   private void OnTriggerStay(Collider other)
   {
      if (other.gameObject.TryGetComponent(out CropField cropField))
      {
         if (cropField.IsWatered())
         {
            currentCropField = cropField;
            EnteredCropField(currentCropField);
         }
      }
   }

   private void OnTriggerExit(Collider other)
   {
      if (other.gameObject.TryGetComponent(out CropField cropField))
      {
         playerAnimator.StopHarvestingAnimation();
         currentCropField = null;
      }
   }

   public void HarvestingStartCallback()
   {
      
      canHarvest = true;
   }

   public void HarvestingStopCallback()
   {
      canHarvest = false;
   }
}
