using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject phase2Prefab;
    public GameObject corpsePrefab; 
    public GameObject deathEffectPrefab;
    public float detectionRange = 10f;
    
    protected Transform target;
    protected Animator animator;
    protected Rigidbody2D rb;
    protected NavMeshAgent agent;
    protected bool isDead = false;

    protected virtual void Start()
    {
        target = FindAnyObjectByType<PlayerController>().transform; 
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false; 
        agent.updateUpAxis = false;
    }

    private void OnEnable()
    {
        EventManager.OnEnemyDeath += HandleDeath;  
    }

    private void OnDisable()
    {
        EventManager.OnEnemyDeath -= HandleDeath;  
    }

    protected virtual void FixedUpdate()
    {
        if (isDead) return;

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

    protected virtual void MoveTowardsPlayer()
    {
        agent.SetDestination(target.position); 

        Vector2 direction = (target.position - transform.position).normalized;

        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Horizontal", direction.x);
        animator.SetBool("isMoving", true);

        if (direction.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);
        else if (direction.x > 0)
            transform.localScale = new Vector3(1, 1, 1);
    }

    protected virtual void HandleDeath(Enemy enemy)
    {
        if (enemy != this) return;
        
        if (isDead) return;
        isDead = true;

        agent.enabled = false;
        animator.SetTrigger("Death");

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null) rb.simulated = false; 
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null) collider.enabled = false;

        if (corpsePrefab) // ?????
        {
            Instantiate(corpsePrefab, transform.position, Quaternion.identity);
        }

        if (deathEffectPrefab)
        {
            Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
        }

        if (phase2Prefab)
        {
            Instantiate(phase2Prefab, transform.position, Quaternion.identity);
        }

        Destroy(gameObject, 3f);
    }

}
