using System.Collections.Generic;
using Environment.Objects;
using Events;
using UnityEngine;

public class SpawnObjectController : MonoBehaviour
{
    private EventManager eventManager = EventManager.Instance;
    private PositioningConfiguration positioningConfiguration;

    private Dictionary<ObjectTypes, List<GameObject>> freeObjects = new Dictionary<ObjectTypes, List<GameObject>>();
    private Dictionary<ObjectTypes, List<GameObject>> usedObjects = new Dictionary<ObjectTypes, List<GameObject>>();

    public void Awake()
    {
        positioningConfiguration = Configurations.PositioningConfiguration;
        eventManager.RegisterForEvent(EventTypes.RoomEntered, OnRoomEntered);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ClearRoom();
            SpawnRandomObjects(0);
        }
    }

    private void SpawnRandomObjects(int roomNumber)
    {
        if (roomNumber > positioningConfiguration.RoomDatas.Length - 1)
        {
            Debug.LogError("There is no object configuration set for room number " + roomNumber);
            return;
        }

        RoomConfigData roomData = positioningConfiguration.RoomDatas[roomNumber];

        if (roomData.ObjectsToSpawn.Length == 0)
        {
            Debug.LogError("No objects set for room number " + roomNumber);
        }

        List<Vector3> usedPositions = new List<Vector3>();

        foreach (PositionConfigData positionConfigData in roomData.ObjectsToSpawn)
        {
            PositionData chosenPosition;
            List<PositionData> possiblePositions = new List<PositionData>(positionConfigData.PossibleObjectPositions);
            int currentTries = 0;

            do
            {
                int index = Random.Range(0, positionConfigData.PossibleObjectPositions.Length - 1);
                chosenPosition = possiblePositions[index];
                if (CheckIfFree(usedPositions, chosenPosition.Position))
                {
                    break;
                }
                else
                {
                    possiblePositions.Remove(chosenPosition);
                    chosenPosition = null;
                }
            } while (possiblePositions.Count > 0);

            if (chosenPosition == null)
            {
                Debug.LogError("There was no free position for an object of type " + positionConfigData.ObjectType +
                               " in room " + roomNumber);
                return;
            }

            usedPositions.Add(chosenPosition.Position);
            GameObject spawnedObject = GetAvailableGameObject(positionConfigData.ObjectType);

            if (spawnedObject == null)
            {
                spawnedObject = Instantiate(positionConfigData.GameObjectToSpawn);
            }

            spawnedObject.SetActive(true);
            spawnedObject.transform.position = new Vector3(chosenPosition.Position.x, chosenPosition.Position.y,
                chosenPosition.Position.z);
            spawnedObject.transform.rotation = new Quaternion(chosenPosition.Rotation.x, chosenPosition.Rotation.y,
                chosenPosition.Rotation.z, chosenPosition.Rotation.w);
            if (usedObjects.ContainsKey(positionConfigData.ObjectType))
            {
                usedObjects[positionConfigData.ObjectType].Add(spawnedObject);
            }
            else
            {
                usedObjects.Add(positionConfigData.ObjectType, new List<GameObject> {spawnedObject});
            }
        }
    }

    private void ClearRoom()
    {
        foreach (KeyValuePair<ObjectTypes, List<GameObject>> keyValuePair in usedObjects)
        {
            if (!freeObjects.ContainsKey(keyValuePair.Key))
            {
                freeObjects.Add(keyValuePair.Key, new List<GameObject>());
            }

            foreach (GameObject spawnedObject in keyValuePair.Value)
            {
                freeObjects[keyValuePair.Key].Add(spawnedObject);
            }
        }

        usedObjects.Clear();
    }

    private GameObject GetAvailableGameObject(ObjectTypes objectType)
    {
        List<GameObject> availableObjects;
        if (freeObjects.TryGetValue(objectType, out availableObjects))
        {
            GameObject availableObject = availableObjects[availableObjects.Count - 1];
            availableObjects.Remove(availableObject);
            freeObjects[objectType] = availableObjects;
            return availableObject;
        }

        return null;
    }

    private bool CheckIfFree(List<Vector3> usedPositions, Vector3 positionToCheck)
    {
        foreach (Vector3 usedPosition in usedPositions)
        {
            if (Vector3.Distance(usedPosition, positionToCheck) < 0.1f)
            {
                return false;
            }
        }

        return true;
    }

    private void OnRoomEntered(IEvent roomEnteredEvent)
    {
        RoomEnteredEvent eventArgs = (RoomEnteredEvent) roomEnteredEvent;

        SpawnRandomObjects(eventArgs.RoomNumber);
    }
}