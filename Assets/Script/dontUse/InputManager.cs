using UnityEngine;
using UnityEngine.Events;


#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif


public class InputManager : MonoBehaviour
{
    [Header("Move")]
    public Vector2 look;

    [Header("Parts")]
    public bool fire;

    [Header("Mouse Cursor Settings")]
    public bool cursorLocked = true;
    public bool cursorInputForLook = true;



#if ENABLE_INPUT_SYSTEM

    public void OnLook(InputValue value)
    {
        LookInput(value.Get<Vector2>());
    }

    public void OnFire(InputValue value)
    {
        FireInput(value.isPressed);
    }

#endif

    public void LookInput(Vector2 newLookDirection)
    {
        look = newLookDirection;
    }

    public void FireInput(bool newMoveDirection)
    {
        fire = newMoveDirection;
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        SetCursorState(cursorLocked);
    }

    private void SetCursorState(bool newState)
    {
        Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
    }

}
