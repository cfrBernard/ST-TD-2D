using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerConfig playerConfig; 
    private Animator animator;
    private Rigidbody2D rb;

    private Vector2 currentVelocity; 

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 input = InputManager.Instance.GetMovementInput();

        // Dead zone input
        if (input.magnitude < playerConfig.deadZone)
        {
            input = Vector2.zero; 
            animator.SetBool("isMoving", false); // Idle
        }
        else
        {
            input = input.normalized; 
            animator.SetFloat("Vertical", input.y);
            animator.SetFloat("Horizontal", input.x);
            animator.SetBool("isMoving", true); // Movement

            if (input.x < 0) // Left Flip X
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (input.x > 0) // Right Flip X
            {
                transform.localScale = new Vector3(1, 1, 1);
            }

            // Acceleration
            currentVelocity = Vector2.MoveTowards(currentVelocity, input * playerConfig.moveSpeed, playerConfig.acceleration * Time.fixedDeltaTime);
        }

        // Deceleration 
        if (input == Vector2.zero)
        {
            currentVelocity = Vector2.MoveTowards(currentVelocity, Vector2.zero, playerConfig.deceleration * Time.fixedDeltaTime);
        }

        // Apply movement
        rb.MovePosition(rb.position + currentVelocity * Time.fixedDeltaTime);
    }





}
