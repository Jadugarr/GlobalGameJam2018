using Events;
using UnityEngine;
using UnityEditor.Animations;

public class OpenDrawerComponent : MonoBehaviour
{
    private Animator animator;

    // Use this for initialization
    void Start()
    {
        EventManager.Instance.RegisterForEvent(EventTypes.BedButtonPressed, OnBedButtonPressed);
        animator = GetComponent<Animator>();
    }

    private void OnBedButtonPressed(IEvent evtData)
    {
        animator.SetBool("Open", true);
    }
}