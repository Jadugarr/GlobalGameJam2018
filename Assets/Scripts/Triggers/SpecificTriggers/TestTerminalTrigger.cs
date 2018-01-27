using Events;
using UnityEngine;

namespace Triggers.SpecificTriggers
{
    public class TestTerminalTrigger : TriggerComponent
    {
        [SerializeField] private string requiredInput;
        [SerializeField] private TerminalComponent terminal;

        public override void Activate()
        {
            base.Activate();
            terminal.Activate(true);
        }

        public override void Deactivate()
        {
            base.Deactivate();
            terminal.Activate(false);
        }

        protected override void AddEventListeners()
        {
            eventManager.RegisterForEvent(EventTypes.SendTerminalInput, OnTerminalInput);
        }

        protected override void RemoveEventListeners()
        {
            eventManager.RemoveFromEvent(EventTypes.SendTerminalInput, OnTerminalInput);
        }

        private void OnTerminalInput(IEvent eventData)
        {
            SendTerminalInputEvent terminalInput = (SendTerminalInputEvent) eventData;

            if (terminalInput.Input.ToLower() == requiredInput.ToLower())
            {
                eventManager.FireEvent(EventTypes.TriggerActivated, new TriggerActivatedEvent(TriggerId));
            }
        }
    }
}