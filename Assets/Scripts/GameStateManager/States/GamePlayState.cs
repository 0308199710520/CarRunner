using Input;
using UnityEngine;

namespace GameStateManager.States
{
    public class GamePlayState : BaseGameState
    {
        private InputManager _input;
        private PlayerStatsManager _playerStats;
        public override void OnStart()
        {
            _input = Manager.Input;
            _playerStats = Manager.PlayerStats;
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
                    Manager.Rb.velocity = Vector3.left * (_playerStats.GetSpeed() * Time.deltaTime);
                    break;
                }
                case RightState.Right:
                {
                    Manager.Rb.velocity = Vector3.right * (_playerStats.GetSpeed() * Time.deltaTime);
                    break;
                }
            }
        }

        private void ChangeState()
        {
            if (_input.InputMenuAndBack.CurrentState == ButtonState.Down && !_input.InputMenuAndBack.GetPolled())
                Manager.SwitchState(Manager.PauseState);
        }
    }
}