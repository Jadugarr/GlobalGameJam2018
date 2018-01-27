namespace Events
{
    public class ButtonPressedEvent : IEvent
    {
        public int ButtonId;

        public ButtonPressedEvent(int buttonId)
        {
            ButtonId = buttonId;
        }
    }
}