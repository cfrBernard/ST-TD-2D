using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject playerPrefab;
    public LevelGenerator levelGenerator;
    public GameObject currentFloor;

    private int floorNumber = 1;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1)) // Test : F1 démarre une nouvelle partie
        {
            StartGame();
        }
        if (Input.GetKeyDown(KeyCode.F2)) // Test : F2 passe à l’étage suivant
        {
            NextFloor();
        }
        if (Input.GetKeyDown(KeyCode.F3)) // Test : F3 simule un Game Over
        {
            GameOver();
        }
    }

    public void StartGame()
    {
        floorNumber = 1;
        SpawnPlayer();
        GenerateFloor();
    }

    private void SpawnPlayer()
    {
        Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
    }

    public void GenerateFloor()
    {
        if (currentFloor != null) Destroy(currentFloor); // Supprime l’ancien étage
        currentFloor = new GameObject("Floor_" + floorNumber); // Contiendra les rooms
        
        // Appeler la méthode de génération dans LevelGenerator
        levelGenerator.GenerateLevel(floorNumber, currentFloor); // Passer l'étage actuel à générer
    }

    public void NextFloor()
    {
        floorNumber++;
        GenerateFloor();
    }

    public void GameOver()
    {
        Debug.Log("Game Over ! Retour au menu...");
        // Afficher un écran de game over et proposer de recommencer
    }
}


