using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator animator;
    private bool IsOpen = true;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void CloseDoor()
    {
        animator.SetTrigger("Close");
        IsOpen = false;
    }

    public void OpenDoor()
    {
        animator.SetTrigger("Open");
        IsOpen = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && IsOpen)
        {
            // Transition vers la room suivante (à gérer avec le RoomManager)
            Debug.Log("Le joueur passe à travers la porte !");
        }
    }
}

