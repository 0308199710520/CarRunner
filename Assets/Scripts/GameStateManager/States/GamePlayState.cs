using Input;
using Unity.VisualScripting.FullSerializer;
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
            MoveCube();
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
                    Debug.Log("None");
                    break;
                }
                case RightState.Left:
                {
                    Debug.Log("Left");
                    break;
                    
                }
                case RightState.Right:
                {
                    Debug.Log("Right");
                    break;
                }
            }
        }
    }
}