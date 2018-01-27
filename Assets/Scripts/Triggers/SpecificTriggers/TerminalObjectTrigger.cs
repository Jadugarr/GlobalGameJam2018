using Events;
using UnityEngine;

namespace Triggers.SpecificTriggers
{
    public class TerminalObjectTrigger : TriggerComponent
    {
        [SerializeField] private string requiredInput;
        [SerializeField] private TerminalComponent terminal;
        [SerializeField] private LogComponent logComponent;
        [SerializeField] private string successOutput;
        [SerializeField] private string failOutput;
        [SerializeField] private GameObject[] objectsToShow;

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
                if (logComponent)
                {
                    logComponent.DisplayText(successOutput.ToUpper(), true);
                }
                foreach (GameObject objectToShow in objectsToShow)
                {
                    objectToShow.SetActive(true);
                }
                eventManager.FireEvent(EventTypes.TriggerActivated, new TriggerActivatedEvent(TriggerId));
            }
            else
            {
                if (logComponent)
                {
                    logComponent.DisplayText(failOutput.ToUpper(), false);
                }
            }
        }
    }
}