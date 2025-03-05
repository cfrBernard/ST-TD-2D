using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float detectionRange = 10f;
    public GameObject corpsePrefab; 

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

    protected virtual void HandleDeath()
    {
        if (isDead) return;
        
        isDead = true;

        agent.enabled = false;
        animator.SetTrigger("Death");

        if (corpsePrefab)
        {
            Instantiate(corpsePrefab, transform.position, Quaternion.identity);
        }
        Destroy(gameObject, 2f);
    }

}
