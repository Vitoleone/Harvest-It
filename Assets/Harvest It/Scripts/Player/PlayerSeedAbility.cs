using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerAnimator))]
[RequireComponent(typeof(PlayerToolSelector))]
public class PlayerSeedAbility : MonoBehaviour
{
   [Header("Attributes")] 
   private PlayerAnimator playerAnimator;
   private PlayerToolSelector playerToolSelector;
   [Header("Settings")] 
   private CropField currentCropField;

   private void Start()
   {
      playerAnimator = GetComponent<PlayerAnimator>();
      playerToolSelector = GetComponent<PlayerToolSelector>();
      SeedParticles.onSeedCollided += SeedsCollidedCallback;
      CropField.onFullySeeded += CropFieldOnFullySeeded;
      playerToolSelector.onToolSelected += ToolSelectedCallBack;
   }

  

   private void OnDestroy()
   {
      SeedParticles.onSeedCollided -= SeedsCollidedCallback;
      CropField.onFullySeeded -= CropFieldOnFullySeeded;
      playerToolSelector.onToolSelected -= ToolSelectedCallBack;
   }
  
   private void CropFieldOnFullySeeded(CropField cropField)
   {
      if(cropField == currentCropField)
         playerAnimator.StopSeedingAnimation();
   }

   private void ToolSelectedCallBack(PlayerToolSelector.Tool selectedTool)
   {
      if (!playerToolSelector.CanSeed())
      playerAnimator.StopSeedingAnimation();
   }
   void SeedsCollidedCallback(Vector3 [] seedPositions)
   {
      if (currentCropField == null)
         return;
      currentCropField.SeedsCollidedCallback(seedPositions);

   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.TryGetComponent(out CropField cropField))
      {
         if (cropField.IsEmpty())
         {
            
            currentCropField = cropField;
            EnteredCropField(currentCropField);
         }
      }
   }

   private void EnteredCropField(CropField cropField)
   {
      if (playerToolSelector.CanSeed())
         playerAnimator.PlaySeedingAnimation();
      
   }

   private void OnTriggerStay(Collider other)
   {
      if (other.gameObject.TryGetComponent(out CropField cropField))
      {
         EnteredCropField(cropField);
      }
   }

   private void OnTriggerExit(Collider other)
   {
      if (other.gameObject.TryGetComponent(out CropField cropField))
      {
         playerAnimator.StopSeedingAnimation();
         currentCropField = null;
      }
   }
}
