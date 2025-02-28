using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private PlayerConfig playerConfig;
    [SerializeField] private Transform shootPoint;

    private float lastShotTime;

    private void Update() // Fixed ?
    {
        Vector2 shootDir = InputManager.Instance.GetShootDirection();
        Vector2 playerDir = transform.up;

        if (shootDir != Vector2.zero && Time.time > lastShotTime + (1f / playerConfig.fireRate))
        {
            Shoot(shootDir);
            lastShotTime = Time.time;
        }
    }

    private void Shoot(Vector2 direction)
    {
        GameObject projectile = ProjectilePool.Instance.GetProjectile();
        projectile.transform.position = shootPoint.position + (Vector3)direction * 0.4f;

        projectile.GetComponent<Projectile>().Initialize(direction, playerConfig);
    }
}

