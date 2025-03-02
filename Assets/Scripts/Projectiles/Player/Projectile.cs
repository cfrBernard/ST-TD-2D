using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private GameObject particlePrefab; 

    private Vector2 moveDirection;
    private float moveSpeed;
    private float maxDistance;
    private float distanceTraveled;

    public void Initialize(Vector2 direction, PlayerConfig config)
    {
        moveDirection = direction.normalized;  
        moveSpeed = config.projectileSpeed;  
        maxDistance = config.projectileDistance;  
        distanceTraveled = 0f;  
    }

    private void FixedUpdate()
    {
        // Calculate the projectile movement
        float moveStep = moveSpeed * Time.fixedDeltaTime;
        transform.position += (Vector3)moveDirection * moveStep;
        distanceTraveled += moveStep;
    
        if (distanceTraveled >= maxDistance)
        {
            ResetProjectile();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall") || other.CompareTag("Enemy"))
        {
            ResetProjectile();  
        }
    }

    private void ResetProjectile()
    {
        // Instantiate particles with a specific seed
        Instantiate(particlePrefab, transform.position, Quaternion.identity);

        ProjectilePool.Instance.ReturnProjectile(gameObject); 
    }
}
