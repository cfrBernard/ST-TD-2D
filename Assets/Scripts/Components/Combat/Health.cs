using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    public float maxHP = 10f;
    private float currentHP;

    public event Action OnDeath; 

    private void Awake()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(float amount)
    {
        currentHP -= amount;
        if (currentHP <= 0)
        {
            OnDeath?.Invoke(); 
            Destroy(gameObject);
        }
    }

    public float GetHealth() => currentHP;
}
