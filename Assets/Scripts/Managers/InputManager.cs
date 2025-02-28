using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActions;  
    public static InputManager Instance { get; private set; }
    
    private InputAction moveAction;
    private InputAction shootAction; 

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        moveAction = inputActions.FindAction("Player/Move");
        shootAction = inputActions.FindAction("Player/Shoot");
        // bombAction = inputAction.FindAction("Player/Bomb");
    }

    private void OnEnable()
    {
        moveAction.Enable();
        shootAction.Enable();  
    }

    private void OnDisable()
    {
        moveAction.Disable();
        shootAction.Disable();
    }

    public Vector2 GetMovementInput()
    {
        return moveAction.ReadValue<Vector2>();
    }

    public Vector2 GetShootDirection()
    {
        Vector2 input = shootAction.ReadValue<Vector2>();

        if (input.magnitude < 0.5f) return Vector2.zero;

        if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
            return new Vector2(Mathf.Sign(input.x), 0);
        else
            return new Vector2(0, Mathf.Sign(input.y));
    }
}
