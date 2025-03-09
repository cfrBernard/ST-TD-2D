using UnityEngine;
using System.Collections.Generic;

public class RoomDatabase : MonoBehaviour
{
    private Dictionary<string, RoomData> roomDatabase = new Dictionary<string, RoomData>();
    private Dictionary<RoomData.RoomType, Dictionary<int, Dictionary<string, List<RoomData>>>> roomByTypeFloorAndDoors 
        = new Dictionary<RoomData.RoomType, Dictionary<int, Dictionary<string, List<RoomData>>>>();

    private void Awake()
    {
        LoadAllRooms();
    }

    // Chargement automatique depuis Resources
    private void LoadAllRooms()
    {
        RoomData[] rooms = Resources.LoadAll<RoomData>("Rooms/RoomData");
        foreach (var room in rooms)
        {
            AddRoomData(room);
        }
    }

    // Ajout des rooms avec indexation
    public void AddRoomData(RoomData roomData)
    {
        if (!roomDatabase.ContainsKey(roomData.roomID))
        {
            roomDatabase.Add(roomData.roomID, roomData);

            if (!roomByTypeFloorAndDoors.ContainsKey(roomData.roomType))
                roomByTypeFloorAndDoors[roomData.roomType] = new Dictionary<int, Dictionary<string, List<RoomData>>>();

            if (!roomByTypeFloorAndDoors[roomData.roomType].ContainsKey(roomData.floorIndex))
                roomByTypeFloorAndDoors[roomData.roomType][roomData.floorIndex] = new Dictionary<string, List<RoomData>>();

            string doorKey = GetDoorKey(roomData.doors);

            if (!roomByTypeFloorAndDoors[roomData.roomType][roomData.floorIndex].ContainsKey(doorKey))
                roomByTypeFloorAndDoors[roomData.roomType][roomData.floorIndex][doorKey] = new List<RoomData>();

            roomByTypeFloorAndDoors[roomData.roomType][roomData.floorIndex][doorKey].Add(roomData);
        }
    }

    // Récupérer une Room selon type et étage
    public RoomData GetRoomDataByType(RoomData.RoomType roomType, int floorIndex)
    {
        if (roomByTypeFloorAndDoors.ContainsKey(roomType) &&
            roomByTypeFloorAndDoors[roomType].ContainsKey(floorIndex))
        {
            List<RoomData> allRooms = new List<RoomData>();

            foreach (var roomsList in roomByTypeFloorAndDoors[roomType][floorIndex].Values)
            {
                allRooms.AddRange(roomsList);
            }

            if (allRooms.Count > 0)
                return allRooms[Random.Range(0, allRooms.Count)]; // random
        }

        return null; 
    }


    // Récupérer une Room selon type, étage et portes
    public RoomData GetRoomDataByTypeAndDoors(RoomData.RoomType roomType, int floorIndex, bool[] doorsConditions)
    {
        string doorKey = GetDoorKey(doorsConditions);

        if (roomByTypeFloorAndDoors.ContainsKey(roomType) &&
            roomByTypeFloorAndDoors[roomType].ContainsKey(floorIndex) &&
            roomByTypeFloorAndDoors[roomType][floorIndex].ContainsKey(doorKey))
        {
            List<RoomData> matchingRooms = roomByTypeFloorAndDoors[roomType][floorIndex][doorKey];
            return matchingRooms[Random.Range(0, matchingRooms.Count)]; // random
        }

        return null; 
    }

    // Génère une clé unique pour indexer les rooms selon les portes (ex: "1100" pour [true, true, false, false])
    private string GetDoorKey(bool[] doors)
    {
        return $"{(doors[0] ? "1" : "0")}{(doors[1] ? "1" : "0")}{(doors[2] ? "1" : "0")}{(doors[3] ? "1" : "0")}";
    }
}
