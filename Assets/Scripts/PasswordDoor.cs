using UnityEngine;

public class PasswordDoor : MonoBehaviour
{
    [SerializeField] private DoorController doorController;
    [SerializeField] private GameObject passwordPanel;
    [SerializeField] private string password = "1234";

    public void ShowPasswordPanel()
    {
        passwordPanel.SetActive(true);
    }

    public void TryPassword(string input)
    {
        if (input == password)
        {
            doorController.OpenDoor();
            Debug.Log("Correct password");
        }
        else
        {
            Debug.Log("Wrong password");
        }
    }
}