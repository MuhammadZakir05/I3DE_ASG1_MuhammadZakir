using UnityEngine;

/// <summary>
/// raycasting for door
/// </summary>
public class FPDoorInteract : MonoBehaviour
{
    [SerializeField] private float interactDistance = 2f;
    [SerializeField] private float closeDistance = 4f;

    private DoorController currentDoor;

    /// <summary>
    /// Checks for interaction/distance to close door
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, interactDistance))
            {
                Area2Door area2Door = hit.collider.GetComponentInParent<Area2Door>();

                // Ignore Area 2 due to own script
                if (area2Door != null)
                {
                    return;
                }

                PasswordDoor passwordDoor = hit.collider.GetComponentInParent<PasswordDoor>();

                // Shows password UI
                if (passwordDoor != null)
                {
                    passwordDoor.ShowPasswordPanel();
                    return;
                }

                DoorController door = hit.collider.GetComponentInParent<DoorController>();

                // Open door.
                if (door != null)
                {
                    currentDoor = door;
                    currentDoor.OpenDoor();
                }
            }
        }

        // Close current door when player walks far enough away.
        if (currentDoor != null)
        {
            float distance = Vector3.Distance(transform.position, currentDoor.transform.position);

            if (distance > closeDistance)
            {
                currentDoor.CloseDoor();
                currentDoor = null;
            }
        }
    }
}