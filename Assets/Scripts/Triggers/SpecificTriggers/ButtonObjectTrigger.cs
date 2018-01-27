using Events;
using Triggers;
using UnityEngine;

public class ButtonObjectTrigger : TriggerComponent
{
    [SerializeField] private GameObject objectToShow;
    [SerializeField] private int neededButtonId;

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
            objectToShow.SetActive(true);
            eventManager.FireEvent(EventTypes.TriggerActivated, new TriggerActivatedEvent(TriggerId));
        }
    }
}