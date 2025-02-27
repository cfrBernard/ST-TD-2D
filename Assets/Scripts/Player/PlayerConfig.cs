using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Player/PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    public float moveSpeed = 5f; // Move speed
    public float acceleration = 10f; // Acceleration
    public float deceleration = 10f; // Deceleration
    public float deadZone = 0.2f; // Dead zone input
}
