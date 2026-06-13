using UnityEngine;

public class FPDoorInteract : MonoBehaviour
{
    [SerializeField] private float interactDistance = 2f;
    [SerializeField] private float closeDistance = 4f;

    private DoorController currentDoor;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, interactDistance))
            {
                Debug.Log("Hit: " + hit.collider.name);

                DoorController door = hit.collider.GetComponentInParent<DoorController>();

                if (door != null)
                {
                    currentDoor = door;
                    currentDoor.OpenDoor();
                }
            }
        }

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