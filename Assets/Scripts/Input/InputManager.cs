using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    public RightState rightState = RightState.None;



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
    }
}