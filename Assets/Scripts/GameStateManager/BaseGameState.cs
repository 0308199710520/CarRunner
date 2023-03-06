namespace GameStateManager
{
    public abstract class BaseGameState
    {
        internal GameStateMachine Manager;

        public abstract void OnStart();

        public abstract void OnUpdate();

        public abstract void OnLeave();
    }
}