using UnityEngine;

namespace Triggers
{
    [CreateAssetMenu(fileName = "TriggerConfiguration", menuName = "Configurations/TriggerConfiguration")]
    public class TriggerConfiguration : ScriptableObject
    {
        public int[] TriggerIds;
    }
}