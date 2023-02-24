using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
    public class InputManager : MonoBehaviour
    {
        public RightState RightState { get; private set; } = RightState.None;
        public Button ChangeState { get; private set; } = new Button();
        [SerializeField] private bool DEBUGINPUT = false;


        public void LateUpdate()
        {
            if (ChangeState.CurrentState == ButtonState.Down)
            {
                ChangeState.HoldTime += Time.deltaTime;
            }

            if (DEBUGINPUT)
            {
                Debug.Log($"Switch State: CurrentState = {ChangeState.CurrentState}    Hold Time = {ChangeState.HoldTime}    Polled={ChangeState.Polled}");
            }
        }

        public void OnRight(InputValue input)
        {
            switch (input.Get<float>())
            {
                case -1:
                {
                    RightState = RightState.Left;
                    break;
                }
                case 1:
                {
                    RightState = RightState.Right;
                    break;
                }
                default:
                {
                    RightState = RightState.None;
                    break;
                }
            }
        }
        
        public void OnStateSwitch(InputValue input)
        {
            if (input.Get<float>() == 0)
            {
                ChangeState.OnRelease();
            }
            else
            {
                ChangeState.Held();    
            }
        }
    }
}