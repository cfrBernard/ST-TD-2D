using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    public float maxHP = 10f;
    private float currentHP;

    private void Awake()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(float amount)
    {
        currentHP -= amount;
        if (currentHP <= 0)
        {
            EventManager.TriggerEnemyDeath();
        }
    }

    public float GetHealth() => currentHP;
}
