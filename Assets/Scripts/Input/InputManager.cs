using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
    public class InputManager : MonoBehaviour
    {
        public RightState RightState { get; private set; } = RightState.None;
        [SerializeField] private bool DEBUGINPUT = false;
    
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
#if UNITY_EDITOR
            if (DEBUGINPUT) print(RightState);
#endif
        }
    }
}