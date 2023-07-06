using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerAnimator))]
public class PlayerController : MonoBehaviour
{
   [Header("Elements")] 
   [SerializeField] private Joystick joystick;
   private PlayerAnimator playerAnimator;
   private CharacterController characterController;
   [Header("Settings")] 
   [SerializeField] private float moveSpeed;

   private void Start()
   {
      characterController = GetComponent<CharacterController>();
      playerAnimator = GetComponent<PlayerAnimator>();
   }

   private void Update()
   {
      Movement();
   }

   private void Movement()
   {
      Vector3 moveVector = joystick.GetMoveVector() * moveSpeed * Time.deltaTime / Screen.width;
      moveVector.z = moveVector.y;
      moveVector.y = 0;
      characterController.Move(moveVector);
      playerAnimator.ManageAnimations(moveVector);
   }
}
