using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

[RequireComponent(typeof(PlayerAnimator))]
[RequireComponent(typeof(PlayerToolSelector))]
public class PlayerWaterAbility : MonoBehaviour
{
   [Header("Attributes")] private PlayerAnimator playerAnimator;
   private PlayerToolSelector playerToolSelector;
   [Header("Settings")] private CropField currentCropField;

   private void Start()
   {
      playerAnimator = GetComponent<PlayerAnimator>();
      playerToolSelector = GetComponent<PlayerToolSelector>();
      WaterParticle.onWaterCollided += WaterCollidedCallback;
      CropField.onFullyWatered += CropFieldOnFullyWatered;
      playerToolSelector.onToolSelected += ToolSelectedCallBack;
   }



   private void OnDestroy()
   {
      WaterParticle.onWaterCollided -= WaterCollidedCallback;
      CropField.onFullyWatered -= CropFieldOnFullyWatered;
      playerToolSelector.onToolSelected -= ToolSelectedCallBack;
   }

   private void CropFieldOnFullyWatered(CropField cropField)
   {
      if (cropField == currentCropField)
         playerAnimator.StopWateringAnimation();
   }

   private void ToolSelectedCallBack(PlayerToolSelector.Tool selectedTool)
   {
      if (!playerToolSelector.CanWater())
         playerAnimator.StopWateringAnimation();
   }

   void WaterCollidedCallback(Vector3[] waterPositions)
   {
      if (currentCropField == null)
         return;
      Debug.Log("current tile is not null");
      currentCropField.WaterCollidedCallback(waterPositions);
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.TryGetComponent(out CropField cropField))
      {
         if (cropField.IsSeeded())
         {
            currentCropField = cropField;
            EnteredCropField(currentCropField);
         }
      }
   }

   private void EnteredCropField(CropField cropField)
   {
      if (playerToolSelector.CanWater())
      {
         if (currentCropField == null)
         {
            currentCropField = cropField;
         }
         playerAnimator.PlayWateringAnimation();
      }
   }

   private void OnTriggerStay(Collider other)
   {
      if (other.gameObject.TryGetComponent(out CropField cropField))
      {
         if (cropField.IsSeeded())
         {
            currentCropField = cropField;
            EnteredCropField(cropField);
         }
      }
   }

   private void OnTriggerExit(Collider other)
   {
      if (other.gameObject.TryGetComponent(out CropField cropField))
      {
         playerAnimator.StopWateringAnimation();
         currentCropField = null;
      }
   }
}
