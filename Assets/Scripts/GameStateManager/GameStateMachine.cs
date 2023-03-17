using GameStateManager.States;
using Input;
using UnityEngine;

namespace GameStateManager
{
    public class GameStateMachine : MonoBehaviour
    {
        public readonly GameDeathState DeathState = new();
        public readonly GameLoadingState LoadingState = new();
        public readonly GameMainMenuState MainMenuState = new();
        public readonly GamePauseState PauseState = new();


        // States
        public readonly GamePlayState PlayState = new();
        private BaseGameState _currentState; // References
        public InputManager Input { get; private set; }
        public PlayerStatsManager PlayerStats { get; private set; }

        // Components
        public Rigidbody Rb { get; private set; }

        public void Awake()
        {
            if (PlayerStats == null) PlayerStats = FindObjectOfType<PlayerStatsManager>(); //To Be Reworked When Menu is Added
            if (Input is null) Input = FindObjectOfType<InputManager>();

            if (Rb == null) Rb = GetComponent<Rigidbody>();
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