using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEditor.UI;
using System;
using TMPro;

public class InputManager : MonoBehaviour
{
    public static PlayerInputs inputActions;
    public static InputManager instance;

    public static event Action rebindComplete;
    public static event Action rebindCanceled;
    public static event Action<InputAction, int> rebindStarted;

    [Header("Movement")]
    public Vector2 walking;
    public bool jumping;
    public bool aiming;
    public bool sprinting;
    public bool crouching;
    public Vector2 looking;

    [Header("Combat")]
    public bool shooting;
    public bool aim;
    public bool changeFireMode;
    public bool reloading;

    private void Awake() {
        instance = this;
        inputActions = new PlayerInputs();
        inputActions.Enable();
    }    

    private void Update() {
        walking = inputActions.Movement.Walking.ReadValue<Vector2>();

        inputActions.Movement.Jumping.performed += x => jumping = true;
        inputActions.Movement.Jumping.canceled += x => jumping = false;

        inputActions.Movement.Crouching.performed += x => crouching = true;
        inputActions.Movement.Crouching.canceled += x => crouching = false;

        inputActions.Movement.Sprinting.performed += x => sprinting = true;
        inputActions.Movement.Sprinting.canceled += x => sprinting = false;

        looking = inputActions.Movement.Looking.ReadValue<Vector2>();
        Mathf.Clamp(looking.x, 0, 1);
        Mathf.Clamp(looking.y, 0, 1);

        inputActions.Combat.Shooting.performed += x => shooting = true;
        inputActions.Combat.Shooting.canceled += x => shooting = false;
        inputActions.Combat.Aiming.performed += x => aiming = true;
        inputActions.Combat.Aiming.canceled += x => aiming = false;
        inputActions.Combat.ChangeFireMode.performed += x => changeFireMode = true;
        inputActions.Combat.ChangeFireMode.canceled += x => changeFireMode = false;
        inputActions.Combat.Reload.performed += x => reloading = true;
        inputActions.Combat.Reload.canceled += x => reloading = false;
    }


    public static void StartRebind(string actionName, int bindingIndex, TMP_Text statusText)
    {
        InputAction action = inputActions.asset.FindAction(actionName);

        if(action == null || action.bindings.Count <= bindingIndex){
            Debug.Log("Couldn't find action or binding");
            return;
        }
        
        if(action.bindings[bindingIndex].isComposite){
            var firstPartIndex = bindingIndex + 1;
            if(firstPartIndex < action.bindings.Count && action.bindings[firstPartIndex].isComposite){
                DoRebind(action, bindingIndex,statusText,true);
            }

        }else{
            DoRebind(action, bindingIndex, statusText, false);
        }
    }

    public static void DoRebind(InputAction actionToRebind, int bindingIndex, TMP_Text statusText, bool allCompositeParts)
    {
        if(actionToRebind == null || bindingIndex < 0){
            return;
        }

        statusText.text = $"Press a {actionToRebind.expectedControlType}";

        actionToRebind.Disable();

        var rebind = actionToRebind.PerformInteractiveRebinding(bindingIndex);

        rebind.OnComplete(operation =>
        {
            actionToRebind.Enable();
            operation.Dispose();

            if(allCompositeParts){
                var nextBindingIndex = bindingIndex + 1;
                if(nextBindingIndex < actionToRebind.bindings.Count && actionToRebind.bindings[nextBindingIndex].isComposite){
                    DoRebind(actionToRebind, nextBindingIndex, statusText, allCompositeParts);
                }
            }

            rebindComplete?.Invoke();
        });
        rebind.OnCancel(operation =>
        {
            actionToRebind.Enable();
            operation.Dispose();
            rebindCanceled?.Invoke();
        });

        rebindStarted?.Invoke(actionToRebind, bindingIndex);
        rebind.Start();
    }

    public static string GetBindingName(string actionName, int bindingIndex)
    {
        if(inputActions == null){
            inputActions = new PlayerInputs();
            inputActions.Enable();
        }

        InputAction action = inputActions.asset.FindAction(actionName);

        return action.GetBindingDisplayString(bindingIndex);
    }

    public static void ResetBinding(string actionName, int bindingIndex)
    {
        InputAction action = inputActions.asset.FindAction(actionName);

        if(action == null || action.bindings.Count <= bindingIndex){
            Debug.Log("Coudnt find action or binding");
            return;
        }

        if(action.bindings[bindingIndex].isComposite){
            for (int i = bindingIndex; i < action.bindings.Count && action.bindings[i].isComposite; i++)
            {
                action.RemoveBindingOverride(i);
            }
        }else
        {
            action.RemoveBindingOverride(bindingIndex);
        }
    }
}
