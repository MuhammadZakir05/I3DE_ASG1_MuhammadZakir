using UnityEngine;
using TMPro;

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

    void OnDisable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void SubmitPassword()
    {
        passwordDoor.TryPassword(passwordInput.text);

        passwordInput.text = "";
        gameObject.SetActive(false);
    }

    public void ClosePanel()
    {
        passwordInput.text = "";
        gameObject.SetActive(false);
    }
}