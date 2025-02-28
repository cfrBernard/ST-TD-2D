using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Player/PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    // 🏃‍♂️ Player movement
    public float moveSpeed = 3f;
    public float acceleration = 30f; 
    public float deceleration = 20f; 
    public float deadZone = 0.2f; 

    // 🎯 Shooting and projectiles
    public float projectileDamage = 1f;
    public float projectileSpeed = 10f;
    public float fireRate = 2f; // per sec
    public float projectileDistance = 5f;

    public void ApplyItemEffect(ItemEffect effect)
    {
        // Applies item effects (power-ups, upgrades...)
        // projectileDamage += effect.projectileDamageIncrease;
        // projectileSpeed += effect.projectileDistanceIncrease;
        // fireRate += effect.fireRateIncrease;
    }
}
