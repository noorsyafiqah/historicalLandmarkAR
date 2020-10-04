using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void OnLoginEvent(string username, string password);
public delegate void OnRegisterEvent(string username, string password, string email);

public class LoginGUI : MonoBehaviour
{
    public static OnLoginEvent OnLogin;
    public static OnRegisterEvent OnRegister;

    // Login Variables
    public Text userText;
    public Text passwordText;

    // Register Variables
    public Text reg_userText;
    public Text reg_passwordText;
    public Text reg_emailText;

    public void LoginClicked()
    {
        if (OnLogin != null)
            OnLogin(userText.text, passwordText.text);
    }

    public void RegisterClicked()
    {
        if (OnRegister != null)
            OnRegister(reg_userText.text, reg_passwordText.text, reg_emailText.text);
    }
}