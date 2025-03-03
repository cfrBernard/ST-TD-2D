using UnityEngine;

[CreateAssetMenu(fileName = "ItemEffect", menuName = "Config/ItemEffect")]
public class ItemEffect : ScriptableObject
{
    public float projectileDamageIncrease;
    public float projectileDistanceIncrease;
    public float fireRateIncrease;
}
