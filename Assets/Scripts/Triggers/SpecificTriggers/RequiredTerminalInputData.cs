using System;

namespace Triggers.SpecificTriggers
{
    [Serializable]
    public class RequiredTerminalInputData
    {
        public int TriggerId;
        public string RequiredInput;
        public string SuccessfulOutput;
    }
}