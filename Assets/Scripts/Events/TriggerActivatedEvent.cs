namespace Events
{
    public class TriggerActivatedEvent : IEvent
    {
        public int TriggerId;

        public TriggerActivatedEvent(int triggerId)
        {
            TriggerId = triggerId;
        }
    }
}