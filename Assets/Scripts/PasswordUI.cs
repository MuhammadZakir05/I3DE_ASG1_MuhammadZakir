using UnityEngine;
using TMPro;

/// <summary>
/// Manages password UI input and lock cursor
/// </summary>
public class PasswordUI : MonoBehaviour
{
    public TMP_InputField passwordInput;
    public PasswordDoor passwordDoor;


    void OnEnable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        passwordInput.ActivateInputField();
    }

    /// <summary>
    /// Locks cursor
    /// </summary>
    void OnDisable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    /// <summary>
    /// Checks password
    /// </summary>
    public void SubmitPassword()
    {
        passwordDoor.TryPassword(passwordInput.text);

        passwordInput.text = "";
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Close pw panel
    /// </summary>
    public void ClosePanel()
    {
        passwordInput.text = "";
        gameObject.SetActive(false);
    }
}