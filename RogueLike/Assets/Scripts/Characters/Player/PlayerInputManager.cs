using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour, InputControllers.IPlayerActions
{
    private InputControllers ic;
    private void Awake()
    {
        ic = new InputControllers();
        ic.Player.SetCallbacks(this);
    }
    private void OnEnable()
    {
        ic.Enable();
    }
    private void OnDisable()
    {
        ic.Disable();
    }
    public void OnMovement(InputAction.CallbackContext context)
    {

    }

    public void OnBuy(InputAction.CallbackContext context)
    {
    }
}
