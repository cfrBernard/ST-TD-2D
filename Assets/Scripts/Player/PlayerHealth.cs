using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public PlayerConfig playerConfig; 

    private CameraShake cameraShake;
    private SpriteRenderer spriteRenderer;
    private bool isInvincible = false;
    private float invincibilityTime = 1f; 
    private float currentHealth;

    private Collider2D playerCollider;  
    private Collider2D[] enemyColliders;  

    
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        cameraShake = Camera.main.GetComponent<CameraShake>();
        playerCollider = GetComponent<Collider2D>(); 

        currentHealth = playerConfig.maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && !isInvincible)
        {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        if (!isInvincible)
        {
            currentHealth -= playerConfig.damageTaken; 

            TriggerHitEffect();

            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    private void TriggerHitEffect()
    {
        if (!isInvincible)
        {
            StartCoroutine(InvincibilityRoutine());
            cameraShake.Shake(); 
        }
    }

    private IEnumerator InvincibilityRoutine()
    {
        isInvincible = true;

        DisableEnemyCollisions(true);

        float elapsedTime = 0f;
        while (elapsedTime < invincibilityTime)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled; 
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        spriteRenderer.enabled = true;
        isInvincible = false;

        DisableEnemyCollisions(false);
    }

    private void DisableEnemyCollisions(bool disable)
    {
        enemyColliders = Physics2D.OverlapCircleAll(transform.position, 5f); 

        foreach (var enemyCollider in enemyColliders)
        {
            if (enemyCollider.CompareTag("Enemy"))
            {
                Physics2D.IgnoreCollision(playerCollider, enemyCollider, disable);
            }
        }
    }

    private void Die()
    {
        Debug.Log("Le joueur est mort !");
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }
}
