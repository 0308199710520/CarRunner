namespace GameStateManager
{
    public abstract class BaseGameState
    {
        public GameStateMachine Manager;

        public abstract void OnStart();

        public abstract void OnUpdate();

        public abstract void OnLeave();
    }
}