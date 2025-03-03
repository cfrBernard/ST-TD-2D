using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Player/PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    // Movement
    public float moveSpeed = 3f;
    public float acceleration = 30f; 
    public float deceleration = 20f; 
    public float deadZone = 0.2f; 

    // Shooting
    public float projectileDamage = 1f;
    public float projectileSpeed = 10f;
    public float fireRate = 2f; // per sec
    public float projectileDistance = 5f;

    // Health
    public float maxHealth = 5f;
    public float damageTaken = 1f;

    public void ApplyItemEffect(ItemEffect effect)
    {
        // Applies item effects (power-ups, upgrades...)
        // projectileDamage += effect.projectileDamageIncrease;
        // projectileSpeed += effect.projectileDistanceIncrease;
        // fireRate += effect.fireRateIncrease;
    }
}
