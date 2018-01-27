using UnityEngine;
using Events;

namespace Triggers.SpecificTriggers{
public class Cube1Trigger : TriggerComponent {

		public override void Activate()
        {
			base.Activate();
        }

        public override void Deactivate()
        {
            base.Deactivate();
        }

        protected override void AddEventListeners()
        {
            eventManager.RegisterForEvent(EventTypes.SendTerminalInput, onCubeInput);
        }

        protected override void RemoveEventListeners()
        {
            eventManager.RemoveFromEvent(EventTypes.SendTerminalInput, onCubeInput);
        }

		private void onCubeInput(IEvent data){
			if(Input.GetKey(KeyCode.Q)){
				Debug.Log("'Q' pressed");
				eventManager.FireEvent(EventTypes.TriggerActivated, new TriggerActivatedEvent(TriggerId));
			}
		}
}
}