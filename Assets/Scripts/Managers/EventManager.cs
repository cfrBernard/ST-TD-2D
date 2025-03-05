using System;
using UnityEngine;

public static class EventManager
{
    public static event Action OnPlayerDeath;
    public static void TriggerPlayerDeath()
    {
        OnPlayerDeath?.Invoke();
    }

    public static event Action OnEnemyDeath;
    public static void TriggerEnemyDeath()
    {
        OnEnemyDeath?.Invoke();
    }
    
}
