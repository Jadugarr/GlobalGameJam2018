namespace Events
{
    public class SendTerminalInputEvent : IEvent
    {
        public string Input;

        public SendTerminalInputEvent(string input)
        {
            Input = input;
        }
    }
}