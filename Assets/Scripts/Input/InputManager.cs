using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
    public class InputManager : MonoBehaviour
    {
        public RightState InputRightState { get; private set; } = RightState.None;
        public readonly Button InputMenuAndBack  = new Button();
        public readonly Button InputRight = new Button();
        [SerializeField] private bool DEBUGINPUT = false;
        
        //Constants
        private const float NO_INPUT = 0;

        public void LateUpdate()
        {
            if (InputMenuAndBack.CurrentState == ButtonState.Down)
            {
                InputMenuAndBack.HoldTime += Time.deltaTime;
            }

            if (DEBUGINPUT)
            {
                Debug.Log($"Switch State: CurrentState = {InputMenuAndBack.CurrentState}    Hold Time = {InputMenuAndBack.HoldTime}    Polled={InputMenuAndBack.Polled}");
                Debug.Log($"Switch State: CurrentState = {InputRightState}");
            }
        }

        public void OnRight(InputValue input)
        {
            
            switch (input.Get<float>())
            {
                case -1:
                {
                    InputRightState = RightState.Left;
                    break;
                }
                case 1:
                {
                    InputRightState = RightState.Right;
                    break;
                }
                default:
                {
                    InputRightState = RightState.None;
                    break;
                }
            }
        }
        
        public void OnMenuAndBack(InputValue input)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (input.Get<float>() == NO_INPUT)
            {
                InputMenuAndBack.OnRelease();
            }
            else
            {
                InputMenuAndBack.Held();    
            }
        }
    }
}