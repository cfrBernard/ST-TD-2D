using UnityEngine;

public class RoomDatabaseTester : MonoBehaviour
{
    private void Start()
    {
        RoomDatabase roomDB = FindAnyObjectByType<RoomDatabase>();

        if (roomDB == null)
        {
            Debug.LogError("❌ RoomDatabase not found!");
            return;
        }

        foreach (var room in Resources.LoadAll<RoomData>("Rooms/RoomData"))
        {
            Debug.Log($"📂 Room chargée : ID={room.roomID}, Type={room.roomType}, Floor={room.floorIndex}, Doors={GetDoorString(room.doors)}");
        }

        Debug.Log("✅ Fin du chargement des rooms.");
    }

    private string GetDoorString(bool[] doors)
    {
        return $"{(doors[0] ? "N" : "-")}{(doors[1] ? "S" : "-")}{(doors[2] ? "W" : "-")}{(doors[3] ? "E" : "-")}";
    }
}
