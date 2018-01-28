using System;
using System.Collections.Generic;
using Events;
using Triggers;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    [SerializeField] private TriggerConfiguration triggerConfiguration;
    [SerializeField] private MeshRenderer symbolRenderer;
    [SerializeField] private Material secondSymbol;
    [SerializeField] private GameObject soulWordObject;
    [SerializeField] private Material thirdSymbol;
    [SerializeField] private GameObject guiltWordObject;

    private Dictionary<int, Action[]> additionalHackyEvents = new Dictionary<int, Action[]>();

    private EventManager eventManager = EventManager.Instance;
    private int currentTriggerIndex = -1;
    private List<TriggerComponent> puzzleTriggers = new List<TriggerComponent>();
    private TriggerComponent currentTrigger;

    public void Awake()
    {
        additionalHackyEvents.Add(1, new Action[] {SwitchToSecondSymbol, DisplaySoul});
        additionalHackyEvents.Add(2, new Action[] {SwitchToThirdSymbol});
        additionalHackyEvents.Add(4, new Action[] {DisplayGuilt});

        GameObject[] triggers = GameObject.FindGameObjectsWithTag("Trigger");

        foreach (GameObject trigger in triggers)
        {
            TriggerComponent triggerComponent = trigger.GetComponent<TriggerComponent>();
            if (triggerComponent == null)
            {
                Debug.LogError("GameObject marked as 'Trigger' has no TriggerComponent! Name: " + trigger.name);
            }
            else
            {
                puzzleTriggers.Add(triggerComponent);
            }
        }

        eventManager.RegisterForEvent(EventTypes.TriggerActivated, OnTriggerActivated);
        eventManager.FireEvent(EventTypes.TriggersCollected, null);
        ActivateNextTrigger();
    }

    private void ActivateNextTrigger()
    {
        currentTriggerIndex++;

        if (currentTriggerIndex < triggerConfiguration.TriggerIds.Length)
        {
            int nextTriggerId = triggerConfiguration.TriggerIds[currentTriggerIndex];
            TriggerComponent nextTrigger = GetTriggerComponent(nextTriggerId);

            if (nextTrigger)
            {
                currentTrigger = nextTrigger;
                currentTrigger.Activate(nextTriggerId);
            }
            else
            {
                Debug.LogError("No trigger component in scene with id " + nextTriggerId);
            }
        }
        else
        {
            eventManager.FireEvent(EventTypes.AllTriggersActivated, null);
            Debug.Log("All triggers activated!");
        }
    }

    private TriggerComponent GetTriggerComponent(int TriggerId)
    {
        foreach (TriggerComponent triggerComponent in puzzleTriggers)
        {
            if (triggerComponent.HasId(TriggerId))
            {
                return triggerComponent;
            }
        }

        return null;
    }

    private void OnTriggerActivated(IEvent eventData)
    {
        TriggerActivatedEvent triggerActivatedEvent = (TriggerActivatedEvent) eventData;

        if (additionalHackyEvents.ContainsKey(triggerActivatedEvent.TriggerId))
        {
            foreach (Action additionalHackyEvent in additionalHackyEvents[triggerActivatedEvent.TriggerId])
            {
                additionalHackyEvent();
            }
        }

        if (currentTrigger.HasId(triggerActivatedEvent.TriggerId))
        {
            currentTrigger.Deactivate();
            ActivateNextTrigger();
        }
        else
        {
            Debug.LogError("Somehow tried to activate a trigger that isn't active! Received: " +
                           triggerActivatedEvent.TriggerId);
        }
    }

    private void SwitchToSecondSymbol()
    {
        symbolRenderer.material = secondSymbol;
    }

    private void SwitchToThirdSymbol()
    {
        symbolRenderer.material = thirdSymbol;
    }

    private void DisplaySoul()
    {
        soulWordObject.SetActive(true);
    }

    private void DisplayGuilt()
    {
        guiltWordObject.SetActive(true);
    }
}