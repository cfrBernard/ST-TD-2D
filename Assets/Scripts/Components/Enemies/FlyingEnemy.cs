using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public float detectionRange = 10f;
    public float speed = 2.5f; 

    private Transform target;
    private Animator animator;

    protected virtual void Start()
    {
        target = FindAnyObjectByType<PlayerController>()?.transform;
        animator = GetComponent<Animator>();
    }

    protected virtual void FixedUpdate()
    {
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

    protected virtual void MoveTowardsPlayer()
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
}
