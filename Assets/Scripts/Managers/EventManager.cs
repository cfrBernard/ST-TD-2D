using System;
using UnityEngine;

public static class EventManager
{
    // Player
    public static event Action OnPlayerHit;
    public static void TriggerPlayerHit()
    {
        OnPlayerHit?.Invoke();
    }
    public static event Action OnPlayerDeath;
    public static void TriggerPlayerDeath()
    {
        OnPlayerDeath?.Invoke();
    }


    // Enemy
    public static event Action OnEnemyHit; // <Enemy>
    public static void TriggerEnemyHit()
    {
        OnEnemyHit?.Invoke();
    }
    public static event Action<Enemy> OnEnemyDeath = delegate { };
    public static void TriggerEnemyDeath(Enemy enemy)
    {
        OnEnemyDeath?.Invoke(enemy);
    }
}