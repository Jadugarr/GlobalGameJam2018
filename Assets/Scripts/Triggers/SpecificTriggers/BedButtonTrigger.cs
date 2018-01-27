using Events;
using UnityEngine;

namespace Triggers.SpecificTriggers
{
    public class BedButtonTrigger : TriggerComponent
    {
        [SerializeField] private int neededButtonId;

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
            eventManager.RegisterForEvent(EventTypes.ButtonPressed, OnButtonPressed);
        }

        protected override void RemoveEventListeners()
        {
            eventManager.RemoveFromEvent(EventTypes.ButtonPressed, OnButtonPressed);
        }

        private void OnButtonPressed(IEvent evtData)
        {
            ButtonPressedEvent eventData = (ButtonPressedEvent) evtData;

            if (eventData.ButtonId == neededButtonId)
            {
                eventManager.FireEvent(EventTypes.BedButtonPressed, null);
                eventManager.FireEvent(EventTypes.TriggerActivated, new TriggerActivatedEvent(activeId));
            }
        }
    }
}