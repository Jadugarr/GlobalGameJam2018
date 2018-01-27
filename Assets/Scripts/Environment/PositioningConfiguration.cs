using Environment.Objects;
using UnityEngine;

[CreateAssetMenu(fileName = "PositioningConfiguration", menuName = "Configurations/PositioningConfiguration")]
public class PositioningConfiguration : ScriptableObject
{
    public RoomConfigData[] RoomDatas;
}
