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
				base.AddEventListeners();
			}

			protected override void RemoveEventListeners()
			{
				base.AddEventListeners();
			}

			void Update(){
				if(Input.GetKey(KeyCode.Q)){
					Debug.Log("'Q' pressed");
					eventManager.FireEvent(EventTypes.TriggerActivated, new TriggerActivatedEvent(TriggerId));
				}
			}
	}
}