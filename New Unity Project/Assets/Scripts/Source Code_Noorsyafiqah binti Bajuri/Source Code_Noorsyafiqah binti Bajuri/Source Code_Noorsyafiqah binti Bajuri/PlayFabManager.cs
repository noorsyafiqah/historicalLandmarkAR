using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class PlayFabManager : MonoBehaviour
{
    public static PlayFabManager Instance = null;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        LoginGUI.OnLogin += this.Login;
        LoginGUI.OnRegister += this.Register;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Login(string username, string password)
    {
        LoginWithPlayFabRequest request = new LoginWithPlayFabRequest();
        request.Username = username;
        request.Password = password;
        PlayFabClientAPI.LoginWithPlayFab(request, this.OnLoginSuccess, this.OnError);
    }

    public void Register(string username, string password, string email)
    {
        RegisterPlayFabUserRequest request = new RegisterPlayFabUserRequest();
        request.Username = username;
        request.Password = password;
        request.Email = email;
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }

    public void OnLoginSuccess(LoginResult result)
    {
        GameManager.Instance.SwitchGameState<MainMenuState>();
    }

    public void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        GameManager.Instance.SwitchGameState<MainMenuState>();
    }

    public void OnError(PlayFabError error)
    {
        Debug.LogError(error.ErrorMessage);
    }
}