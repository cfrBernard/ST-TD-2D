using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActions;  
    public static InputManager Instance { get; private set; }
    
    private InputAction moveAction;

    private void Awake()
    {
        if (Instance == null) Instance = this;  
        else Destroy(gameObject);

        moveAction = inputActions.FindAction("Player/Move");
    }

    private void OnEnable()
    {
        moveAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
    }

    public Vector2 GetMovementInput()
    {
        return moveAction.ReadValue<Vector2>();
    }
}
