using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    public RightState rightState { get; private set; } = RightState.None;
    [SerializeField] private bool DEBUGINPUT = false;
    
    public void OnRight(InputValue input)
    {
        switch (input.Get<float>())
        {
            case -1:
            {
                rightState = RightState.Left;
                break;
            }
            case 1:
            {
                rightState = RightState.Right;
                break;
            }
            default:
            {
                rightState = RightState.None;
                break;
            }
        }
    #if UNITY_EDITOR
        if (DEBUGINPUT) print(rightState);
    #endif
    }
}