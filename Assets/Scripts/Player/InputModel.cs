using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputModel
{
    public InputMode CurrentMode { get; private set; } = InputMode.Interaction;

    public void ToggleMode()
    {
        CurrentMode = (CurrentMode == InputMode.Interaction) ? InputMode.Combat : InputMode.Interaction;
    }
}

public enum InputMode
{
    Interaction,
    Combat
}