using UnityEngine;

[CreateAssetMenu(fileName = "RoomData", menuName = "Rooms/New Room Data")]
public class RoomData : ScriptableObject
{
    public string roomID; 
    public int floorIndex; // or = First ID number
    public RoomType roomType;
    public Vector2Int size;
    public bool[] doors = new bool[4];
    // Index 0 = top (North)
    // Index 1 = bottom (South)
    // Index 2 = left (West)
    // Index 3 = Right (East)
    
    [HideInInspector]
    public string prefabPath;

    public enum RoomType { Spawn, Shop, PreBoss, Boss, Combat, Puzzle, Secret }

    private void OnValidate()
    {
        prefabPath = $"Rooms/Floor{floorIndex}/{roomType}/{roomID}";
    }

    public GameObject LoadPrefab()
    {
        return Resources.Load<GameObject>(prefabPath);
    }
}
