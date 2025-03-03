using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float detectionRange = 10f;
    protected Transform playerTransform;
    protected Animator animator;
    protected Rigidbody2D rb;

    protected virtual void Start()
    {
        playerTransform = FindAnyObjectByType<PlayerController>().transform; 
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void FixedUpdate()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);

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
        Vector2 direction = (playerTransform.position - transform.position).normalized;

        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Horizontal", direction.x);
        animator.SetBool("isMoving", true);

        if (direction.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);
        else if (direction.x > 0)
            transform.localScale = new Vector3(1, 1, 1);

        rb.MovePosition(rb.position + direction * moveSpeed * Time.deltaTime);
    }
}
