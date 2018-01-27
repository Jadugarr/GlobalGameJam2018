using Events;
using UnityEngine;

namespace Triggers.SpecificTriggers
{
    public class FirstDoorTerminalLogTrigger : TriggerComponent
    {
        [SerializeField] private RequiredTerminalInputData[] requiredInput;
        [SerializeField] private TerminalComponent terminal;
        [SerializeField] private LogComponent logComponent;
        [SerializeField] private string successOutput;
        [SerializeField] private string failOutput;

        public override void Activate(int activeId)
        {
            base.Activate(activeId);
            terminal.Activate(true);
        }

        public override void Deactivate()
        {
            RemoveEventListeners();
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

            if (terminalInput.Input.ToLower() == GetCurrentRequiredInput().ToLower())
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

        private string GetCurrentRequiredInput()
        {
            foreach (RequiredTerminalInputData requiredTerminalInputData in requiredInput)
            {
                if (requiredTerminalInputData.TriggerId == activeId)
                {
                    return requiredTerminalInputData.RequiredInput;
                }
            }

            return "";
        }
    }
}