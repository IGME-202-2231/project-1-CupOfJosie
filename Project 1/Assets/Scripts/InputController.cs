using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    //Fields
    [SerializeField]
    MovementController movementController;

    [SerializeField]
    BulletManager bulletManager;

    public void OnMove(InputAction.CallbackContext context)
    {
        movementController.SetDirection(context.ReadValue<Vector2>());
    }

    public void OnPress(InputAction.CallbackContext context)
    {
        bulletManager.Spawn();
    }

}
