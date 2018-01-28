using Events;
using UnityEngine;

namespace Triggers.SpecificTriggers
{
    public class FirstDoorTerminalLogTrigger : TriggerComponent
    {
        [SerializeField] private RequiredTerminalInputData[] requiredInput;
        [SerializeField] private TerminalComponent terminal;
        [SerializeField] private LogComponent logComponent;
        [SerializeField] private string failOutput;
        [SerializeField] private int triesRemaining;

        private int triesLeft;

        public override void Activate(int activeId)
        {
            triesLeft = triesRemaining;
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
            RequiredTerminalInputData currentData = GetCurrentRequiredData();

            if (terminalInput.Input.ToLower() == currentData.RequiredInput.ToLower())
            {
                if (logComponent)
                {
                    logComponent.DisplayText(currentData.SuccessfulOutput.ToUpper(), true);
                }
                eventManager.FireEvent(EventTypes.TriggerActivated, new TriggerActivatedEvent(activeId));
            }
            else
            {
                triesLeft--;
                if (logComponent)
                {
                    logComponent.DisplayText(triesLeft + " " + failOutput.ToUpper(), false);
                }

                if (triesLeft <= 0)
                {
                    eventManager.FireEvent(EventTypes.NiggaFuckedUp, null);
                }
            }
        }

        private RequiredTerminalInputData GetCurrentRequiredData()
        {
            foreach (RequiredTerminalInputData requiredTerminalInputData in requiredInput)
            {
                if (requiredTerminalInputData.TriggerId == activeId)
                {
                    return requiredTerminalInputData;
                }
            }

            return null;
        }
    }
}