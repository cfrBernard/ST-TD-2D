using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public RoomDatabase roomDatabase;
    public GameObject roomPrefab;

    // Méthode qui génère un étage basé sur le floorNumber
    public void GenerateLevel(int floorNumber, GameObject floorParent)
    {
        Debug.Log($"Génération de l'étage {floorNumber}...");
        
        RoomData spawnRoomData = roomDatabase.GetRoomDataByType(RoomData.RoomType.Spawn, 1); 
        
        if (spawnRoomData != null)
        {
            GameObject spawnRoomPrefab = spawnRoomData.LoadPrefab();
            if (spawnRoomPrefab != null)
            {
                GameObject spawnRoom = Instantiate(spawnRoomPrefab, Vector3.zero, Quaternion.identity);
                spawnRoom.transform.SetParent(floorParent.transform); // Organiser sous le parent
            }
        }

        // Générer d'autres rooms selon les règles de génération
        // Exemple d'un combat room qui serait générée sur la droite du spawn
        //RoomData combatRoomData = roomDatabase.GetRoomDataById("1F4002"); // Exemple : RoomData "1F4002" (Combat)
        //
        //if (combatRoomData != null)
        //{
        //    GameObject combatRoomPrefab = combatRoomData.LoadPrefab();
        //    if (combatRoomPrefab != null)
        //    {
        //        Vector3 combatRoomPosition = new Vector3(10f, 0f, 0f); // Place la room à droite du spawn
        //        GameObject combatRoom = Instantiate(combatRoomPrefab, combatRoomPosition, Quaternion.identity);
        //        combatRoom.transform.SetParent(floorParent.transform);
        //    }
        //}

        // Ajouter plus de rooms...
    }
}


