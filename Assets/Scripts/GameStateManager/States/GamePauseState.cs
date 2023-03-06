using Input;

namespace GameStateManager.States
{
    public class GamePauseState : BaseGameState
    {
        private InputManager _input;
        public override void OnStart()
        {
            _input = Manager.Input;
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
            if (_input.InputMenuAndBack.CurrentState == ButtonState.Down && ! _input.InputMenuAndBack.GetPolled())
            {
                Manager.SwitchState(Manager.PlayState);
            }
        }
    }
}