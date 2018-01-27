using Events;
using Triggers;
using UnityEngine;

public class ButtonObjectTrigger : TriggerComponent
{
    [SerializeField] private GameObject[] objectsToShow;
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
            foreach (GameObject obj in objectsToShow)
            {
                obj.SetActive(true);
            }
            eventManager.FireEvent(EventTypes.TriggerActivated, new TriggerActivatedEvent(activeId));
        }
    }
}