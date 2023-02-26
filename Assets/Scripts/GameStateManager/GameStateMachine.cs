using GameStateManager.States;
using Input;
using UnityEngine;

namespace GameStateManager
{
    public class GameStateMachine : MonoBehaviour
    {
        public InputManager _input { get; private set; }

        public readonly GamePlayState PlayState = new();
        public readonly GamePauseState PauseState = new();
        public Rigidbody Rb;
        
        
        private BaseGameState _currentState;

        public void Awake()
        {
            if (_input is null)
            {
                _input = FindObjectOfType<InputManager>();
            }

            if (Rb == null)
            {
                Rb = GetComponent<Rigidbody>();
            }
        }

        public void Start()
        {
            _currentState = PlayState;
            _currentState.Manager = this;
            _currentState.OnStart();
        }

        public void Update()
        {
            _currentState.OnUpdate();   
        }

        public void SwitchState(BaseGameState state)
        {
            _currentState.OnLeave();
            _currentState = state;
            _currentState.Manager = this;
            _currentState.OnStart();
        }
    }
}