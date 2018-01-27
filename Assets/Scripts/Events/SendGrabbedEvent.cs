namespace Events
{
	public class SendGrabbedEvent : IEvent
	{
		public bool Grabbed;

		public SendGrabbedEvent(bool grabbed)
		{
			Grabbed = grabbed;
		}
	}
}