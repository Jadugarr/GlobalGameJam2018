using UnityEngine;
using Events;

namespace Triggers.SpecificTriggers{
	public class Cube1Trigger : TriggerComponent {

	    public override void Activate(int activeId)
	    {
	        base.Activate(activeId);
	    }

        public override void Deactivate()
		{
			base.Deactivate();
		}
					
		protected override void AddEventListeners()
		{
			eventManager.RegisterForEvent(EventTypes.SendGrabbed, OnGrabbed);
		}
					
		protected override void RemoveEventListeners()
		{
			eventManager.RemoveFromEvent (EventTypes.SendGrabbed, OnGrabbed);
		}
					
		private void OnGrabbed(IEvent eventData){
			SendGrabbedEvent grabbedEvent = (SendGrabbedEvent)eventData;
			
			if (grabbedEvent.Grabbed) {
				eventManager.FireEvent (EventTypes.TriggerActivated, new TriggerActivatedEvent (activeId));
			}
		}
	}
}