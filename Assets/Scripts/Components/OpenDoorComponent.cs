using Events;
using UnityEngine;

public class OpenDoorComponent : MonoBehaviour
{
    public Animator DoorAnimator;

    // Use this for initialization
    void Start()
    {
        EventManager.Instance.RegisterForEvent(EventTypes.AllTriggersActivated, OnLastTrigger);
    }

    private void OnLastTrigger(IEvent evtData)
    {
        DoorAnimator.SetBool("Open", true);
    }
}