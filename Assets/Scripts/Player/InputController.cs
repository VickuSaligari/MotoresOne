using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour, IController
{
    [SerializeField] private InputView inputView;
    [SerializeField] private Interact interact;
    [SerializeField] private Weapons firstWeapon, secondWeapon;

    private InputModel model = new InputModel();

    private void OnEnable()
    {
        inputView.OnToggleInputMode += InputChange;
        inputView.OnInteract += TryInteract;
        inputView.OnReff += TryReff;
        inputView.OnPrimaryAttack += TryPrimaryAttack;
        inputView.OnSecondaryAttack += TrySecondaryAttack;
    }

    private void OnDisable()
    {
        inputView.OnToggleInputMode -= InputChange;
        inputView.OnInteract -= TryInteract;
        inputView.OnReff -= TryReff;
        inputView.OnPrimaryAttack -= TryPrimaryAttack;
        inputView.OnSecondaryAttack -= TrySecondaryAttack;
    }

    public void InputChange()
    {
        model.ToggleMode();
        Debug.Log($"TAB pressed → Input Mode now changed to: {model.CurrentMode}");
    }

    private void TryInteract()
    {
        Debug.Log("E pressed");
        if (model.CurrentMode == InputMode.Interaction)
        {
            Debug.Log("Item pickup!");
            interact.CheckForItemPickup();
        }
        else
        {
            Debug.Log("[Ignored] Interaction mode required");
        }
    }

    private void TryReff()
    {
        Debug.Log("Q pressed");
        if (model.CurrentMode == InputMode.Interaction)
        {
            Debug.Log("Put down!");
            interact.CheckReff();
        }
        else
        {
            Debug.Log("[Ignored] Interaction mode required");
        }
    }

    private void TryPrimaryAttack()
    {
        Debug.Log("Left click");
        if (model.CurrentMode == InputMode.Combat && firstWeapon != null)
        {
            Debug.Log("Melee attack!");
            firstWeapon.Attack();
        }
        else
        {
            Debug.Log("[Ignored] Combat mode required or weapon missing");
        }
    }

    private void TrySecondaryAttack()
    {
        Debug.Log("Right click");
        if (model.CurrentMode == InputMode.Combat && secondWeapon != null)
        {
            Debug.Log("Gunshot!");
            secondWeapon.Attack();
        }
        else
        {
            Debug.Log("[Ignored] Combat mode required or weapon missing");
        }
    }
}