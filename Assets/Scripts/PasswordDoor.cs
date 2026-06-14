using UnityEngine;

/// <summary>
/// Manages password door
/// </summary>
public class PasswordDoor : MonoBehaviour
{
    [SerializeField] private DoorController doorController;
    [SerializeField] private GameObject passwordPanel;
    [SerializeField] private string password = "1234";

    /// <summary>
    /// Shows pw panel upon interacting
    /// </summary>
    public void ShowPasswordPanel()
    {
        passwordPanel.SetActive(true);
    }

    /// <summary>
    /// Checks pw
    /// </summary>
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