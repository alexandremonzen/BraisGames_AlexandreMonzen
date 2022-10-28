using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class MouseStatusController : Singleton<MouseStatusController>
{
    private void Awake()
    {
        SetMouseVisibilityAndLockState(false, CursorLockMode.Locked);
    }

    public void SetMouseVisibilityAndLockState(bool state, CursorLockMode cursorLockMode)
    {
        Cursor.lockState = cursorLockMode;
        Cursor.visible = state;
    }
}
