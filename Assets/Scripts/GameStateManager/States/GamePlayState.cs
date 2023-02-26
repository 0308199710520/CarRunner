using Input;
using UnityEngine;

namespace GameStateManager.States
{
    public class GamePlayState : BaseGameState
    {
        private InputManager _input;

        public override void OnStart()
        {
            _input = Manager._input;
        }

        public override void OnUpdate()
        {
            MoveCar();
            ChangeState();
        }

        public override void OnLeave()
        {
            
        }

        private void MoveCar()
        {
            switch (_input.InputRightState)
            {
                case RightState.None:
                {
                    Manager.Rb.velocity = Vector3.zero;
                    break;
                }
                case RightState.Left:
                {
                    Manager.Rb.velocity = Vector3.left;
                    break;

                }
                case RightState.Right:
                {
                    Manager.Rb.velocity = Vector3.right;
                    break;
                }
            }
        }

        private void ChangeState()
        {
            if (_input.InputMenuAndBack.CurrentState == ButtonState.Down && ! _input.InputMenuAndBack.GetPolled())
            {
                Manager.SwitchState(Manager.PauseState);
            }
        }
    }
}