namespace Input
{
    public enum RightState
    {
        None,
        Left,
        Right
    }

    public enum ButtonState
    {
        Up,
        Down,
        None
    }

    public class Button
    {
        public ButtonState CurrentState { get; private set; } = ButtonState.None;
        public float HoldTime { get; set; }
        public bool Polled { get; private set; }

        public bool GetPolled()
        {
            var returnValue = Polled;
            Polled = true;
            return returnValue;
        }

        public void Held()
        {
            CurrentState = ButtonState.Down;
        }

        public void OnRelease()
        {
            CurrentState = ButtonState.Up;
            HoldTime = 0;
            Polled = false;
        }
    }
}