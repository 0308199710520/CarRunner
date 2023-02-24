using Input;
using UnityEngine;

namespace GameStateManager.States
{
    public class GamePauseState : BaseGameState
    {
        private InputManager _input;
        public override void OnStart()
        {
            _input = Manager._input;

        }

        public override void OnUpdate()
        {
            SwitchState();
        }

        public override void OnLeave()
        {
            
        }

        public void SwitchState()
        {
            if (_input.ChangeState.CurrentState == ButtonState.Down && ! _input.ChangeState.GetPolled())
            {
                Manager.SwitchState(Manager.PlayState);
            }
        }
    }
}