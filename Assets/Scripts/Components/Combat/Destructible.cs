using NavMeshPlus.Components;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public NavMeshSurface roomNavMesh;  

    private void OnEnable()
    {
        EventManager.OnEnemyDeath += HandleDeath;  
    }

    private void OnDisable()
    {
        EventManager.OnEnemyDeath -= HandleDeath;  
    }

    private void HandleDeath()
    {
        DestroyObstacle();  
    }

    private void DestroyObstacle()
    {
        Destroy(gameObject);
        UpdateNavMeshAsync();
    }

    private void UpdateNavMeshAsync()
    {
        roomNavMesh.UpdateNavMesh(roomNavMesh.navMeshData);
        
        // Opti needed, Delay on multi destroy "REF E1"  and cache "REF E2"

        // REF E2
        // NavMeshBuilder.UpdateNavMeshDataAsync(data, GetBuildSettings(), cachedSources, sourcesBounds); 
    }
}


// REF E1
// private bool isUpdating = false;

// private void DestroyObstacle()
// {
//     Destroy(gameObject);
    
//     if (!isUpdating)
//     {
//         StartCoroutine(DelayedNavMeshUpdate());
//     }
// }

// private IEnumerator DelayedNavMeshUpdate()
// {
//     isUpdating = true;
//     yield return new WaitForSeconds(0.5f); // Temps d'attente avant de recalculer
//     roomNavMesh.UpdateNavMesh(roomNavMesh.navMeshData);
//     isUpdating = false;
// }
