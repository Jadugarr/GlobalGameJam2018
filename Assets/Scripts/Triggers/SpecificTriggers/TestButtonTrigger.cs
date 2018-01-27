using Events;
using UnityEngine;

namespace Triggers.SpecificTriggers
{
    public class TestButtonTrigger : TriggerComponent
    {
        public override void Activate(int activeid)
        {
            base.Activate(activeid);
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
            base.RemoveEventListeners();
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                eventManager.FireEvent(EventTypes.TriggerActivated, new TriggerActivatedEvent(activeId));
            }
        }
    }
}