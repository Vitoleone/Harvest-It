using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
   [Header("Attributes")] 
   [SerializeField] private RectTransform joystickCircle;
   [SerializeField] private RectTransform joystickKnob;

   [Header("Settings")] 
   [SerializeField] private float moveFactor;
   private bool canControl = false;
   private Vector3 clickedPosition;
   private Vector3 move;

   private void Update()
   {
      if (canControl)
      {
         ControlJoystick();
      }
   }

   public void OnClickedJoystickZone()
   {
      clickedPosition = Input.mousePosition;
      ShowJoystick();
      joystickCircle.position = clickedPosition;
   }

   public void ShowJoystick()
   {
      joystickCircle.gameObject.SetActive(true);
      canControl = true;
   }
   public void HideJoystick()
   {
      joystickCircle.gameObject.SetActive(false);
      canControl = false;
      move = Vector3.zero;
   }

   public void ControlJoystick()
   {
      Vector3 currentPosition = Input.mousePosition;
      Vector3 direction = currentPosition - clickedPosition;

      float moveMagnitude = direction.magnitude * moveFactor / Screen.width;
      moveMagnitude = Mathf.Min(moveMagnitude, joystickCircle.rect.width / 2);
      move = direction.normalized * moveMagnitude;
      Vector3 targetPosition = clickedPosition + move;
      joystickKnob.position = targetPosition;
      if (Input.GetMouseButtonUp(0))
      {
         HideJoystick();
      }
   }

   public Vector3 GetMoveVector()
   {
      return move;
   }
}
