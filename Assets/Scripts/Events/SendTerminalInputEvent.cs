namespace Events
{
    public class SendTerminalInputEvent : IEvent
    {
        public string Input;
        public int TerminalId;

        public SendTerminalInputEvent(string input, int terminalId)
        {
            Input = input;
            TerminalId = terminalId;
        }
    }
}