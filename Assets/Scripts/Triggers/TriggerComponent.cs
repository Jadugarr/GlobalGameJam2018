using Events;
using UnityEngine;

namespace Triggers
{
    public class TriggerComponent : MonoBehaviour
    {
        public int[] TriggerIds;
        protected int activeId;

        protected EventManager eventManager = EventManager.Instance;

        public bool HasId(int triggerId)
        {
            foreach (int id in TriggerIds)
            {
                if (triggerId == id)
                {
                    return true;
                }
            }

            return false;
        }

        public virtual void Activate(int activeId)
        {
            this.activeId = activeId;
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