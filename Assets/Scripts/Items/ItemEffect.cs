using UnityEngine;

// 🎁 ScriptableObject pour gérer les power-ups
[CreateAssetMenu(fileName = "ItemEffect", menuName = "Config/ItemEffect")]
public class ItemEffect : ScriptableObject
{
    public float projectileDamageIncrease;
    public float projectileDistanceIncrease;
    public float fireRateIncrease; // 📈 Augmente la cadence de tir
}
