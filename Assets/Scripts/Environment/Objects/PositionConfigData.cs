using System;
using UnityEngine;

namespace Environment.Objects
{
    [Serializable]
    public class PositionConfigData
    {
        public ObjectTypes ObjectType;
        public GameObject GameObjectToSpawn;
        public PositionData[] PossibleObjectPositions;
    }
}