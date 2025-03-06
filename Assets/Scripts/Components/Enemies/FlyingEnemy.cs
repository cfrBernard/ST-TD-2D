using UnityEngine;

public class FlyingEnemy : Enemy
{
    public float speed = 1.5f; 
    
    protected override void Start()
    {
        target = FindAnyObjectByType<PlayerController>().transform; 
        animator = GetComponent<Animator>();
    }

    protected override void FixedUpdate()
    {
        if (isDead) return;
        
        if (target == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, target.position);

        if (distanceToPlayer <= detectionRange)
        {
            MoveTowardsPlayer();
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    protected override void MoveTowardsPlayer()
    {
        Vector2 direction = (target.position - transform.position).normalized;
        transform.position += (Vector3)direction * speed * Time.deltaTime;

        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Horizontal", direction.x);
        animator.SetBool("isMoving", true);

        if (direction.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);
        else if (direction.x > 0)
            transform.localScale = new Vector3(1, 1, 1);
    }

    protected override void HandleDeath(Enemy enemy)
    {
        if (enemy != this) return;

        if (isDead) return;
        isDead = true;

        animator.SetTrigger("Death");

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null) rb.simulated = false; 
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null) collider.enabled = false; 

        if (deathEffectPrefab)
        {
            Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }

}
