using Events;
using UnityEngine;

namespace Triggers.SpecificTriggers
{
    public class SecondDoorTerminalLogTrigger : TriggerComponent
    {
        [SerializeField] private string requiredInput;
        [SerializeField] private TerminalComponent terminal;
        [SerializeField] private LogComponent logComponent;
        [SerializeField] private string successOutput;
        [SerializeField] private string failOutput;

        public void Start()
        {
            eventManager.RegisterForEvent(EventTypes.TriggersCollected, OnTriggersCollected);
        }

        public override void Activate(int activeId)
        {
            base.Activate(activeId);
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
                eventManager.FireEvent(EventTypes.TriggerActivated, new TriggerActivatedEvent(activeId));
            }
            else
            {
                if (logComponent)
                {
                    logComponent.DisplayText(failOutput.ToUpper(), false);
                }
            }
        }

        private void OnTriggersCollected(IEvent evtData)
        {
            eventManager.RemoveFromEvent(EventTypes.TriggersCollected, OnTriggersCollected);
            gameObject.SetActive(false);
        }
    }
}