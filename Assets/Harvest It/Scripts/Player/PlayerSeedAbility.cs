using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerAnimator))]
public class PlayerSeedAbility : MonoBehaviour
{
   [Header("Attributes")] 
   private PlayerAnimator playerAnimator;
   [Header("Settings")] 
   private CropField currentCropField;

   private void Start()
   {
      playerAnimator = GetComponent<PlayerAnimator>();
      SeedParticles.onSeedCollided += SeedsCollidedCallback;
   }

   private void OnDestroy()
   {
      SeedParticles.onSeedCollided -= SeedsCollidedCallback;
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
         playerAnimator.PlaySeedingAnimation();
         currentCropField = cropField;
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
