using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerAnimator))]
public class PlayerSeedAbility : MonoBehaviour
{
   [Header("Attributes")] 
   private PlayerAnimator playerAnimator;

   private void Start()
   {
      playerAnimator = GetComponent<PlayerAnimator>();
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.TryGetComponent(out CropField cropField))
      {
         playerAnimator.PlaySeedingAnimation();
      }
   }

   private void OnTriggerExit(Collider other)
   {
      if (other.gameObject.TryGetComponent(out CropField cropField))
      {
         playerAnimator.StopSeedingAnimation();
      }
   }
}
