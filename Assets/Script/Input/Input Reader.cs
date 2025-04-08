using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static PlayerMovement;

[CreateAssetMenu(fileName = "New Input Reader", menuName = "Input/Input Reader")]
public class InputReader : ScriptableObject, IPlayerActions
{
   public event Action<Vector2> MoveEvent;
   public event Action<bool> KickEvent;
   
   private PlayerMovement playerMovement;

   private void OnEnable()
   {
      if (playerMovement == null)
      {
         playerMovement = new PlayerMovement();
         playerMovement.Player.SetCallbacks(this);
      }

      playerMovement.Player.Enable();
   }

   private void OnDisable()
   {
      playerMovement.Player.Disable();
   }

   public void OnMove(InputAction.CallbackContext ctx)
   {
      MoveEvent?.Invoke(ctx.ReadValue<Vector2>());
   }
   public void OnKick(InputAction.CallbackContext ctx)
   {
      if (ctx.performed)
      {
         KickEvent?.Invoke(true);
      }
      else if (ctx.canceled)
      {
         KickEvent?.Invoke(false);
      }
   }
}
