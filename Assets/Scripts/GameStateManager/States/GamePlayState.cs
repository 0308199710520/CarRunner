using Input;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.XR;

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
            MoveCube();
            ChangeState();
        }

        public override void OnLeave()
        {
            
        }

        private void MoveCube()
        {
            switch (_input.RightState)
            {
                case RightState.None:
                {
                    break;
                }
                case RightState.Left:
                {
                    break;
                    
                }
                case RightState.Right:
                {
                    break;
                }
            }
        }
        private void ChangeState()
        {
            if (_input.ChangeState.CurrentState == ButtonState.Down && ! _input.ChangeState.GetPolled())
            {
                Manager.SwitchState(Manager.PauseState);
            }
        }
    }
}