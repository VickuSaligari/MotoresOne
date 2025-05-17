using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputView : MonoBehaviour
{
    public event Action OnToggleInputMode;
    public event Action OnInteract;
    public event Action OnReff;
    public event Action OnPrimaryAttack;
    public event Action OnSecondaryAttack;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            OnToggleInputMode?.Invoke();

        if (Input.GetKeyDown(KeyCode.E))
            OnInteract?.Invoke();

        if (Input.GetKeyDown(KeyCode.Q))
            OnReff?.Invoke();

        if (Input.GetKeyDown(KeyCode.Mouse0))
            OnPrimaryAttack?.Invoke();

        if (Input.GetKeyDown(KeyCode.Mouse1))
            OnSecondaryAttack?.Invoke();
    }
}
