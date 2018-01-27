using Events;
using UnityEngine;

namespace Triggers
{
    public class TriggerComponent : MonoBehaviour
    {
        public int TriggerId;

        protected EventManager eventManager = EventManager.Instance;

        public virtual void Activate()
        {
            gameObject.SetActive(true);
            AddEventListeners();
        }

        public virtual void Deactivate()
        {
            gameObject.SetActive(false);
            RemoveEventListeners();
        }

        protected virtual void AddEventListeners()
        {
            
        }

        protected virtual void RemoveEventListeners()
        {
            
        }
    }
}