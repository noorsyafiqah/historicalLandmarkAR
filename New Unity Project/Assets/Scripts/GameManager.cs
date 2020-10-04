using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    public List<GameState> gameStates = new List<GameState>();
    public GameState ActiveState = null;

    private void Awake()
    {
        Instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        RegisterGameState<LoginState>();
        RegisterGameState<MainMenuState>();
        RegisterGameState<CharacterCreationState>();
        RegisterGameState<WorldState>();

        SwitchGameState<LoginState>();
    }

    public void Test()
    {
        SwitchGameState<MainMenuState>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RegisterGameState<T>() where T : GameState
    {
        gameStates.Add(Activator.CreateInstance<T>());
    }

    public void SwitchGameState<T>() where T : GameState
    {
        if (ActiveState != null)
        {
            ActiveState.OnDisabled();
        }

        foreach (GameState state in gameStates)
        {
            if (state is T)
            {
                ActiveState = state;
                ActiveState.OnEnabled();
            }
        }
    }
}

public abstract class GameState
{
    public string SceneName;

    public virtual void OnEnabled()
    {
        SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Additive);
    }

    public virtual void OnDisabled()
    {
        SceneManager.UnloadSceneAsync(SceneName);
    }
}

public class LoginState : GameState
{
    public LoginState()
    {
        SceneName = "Login";
    }
}

public class MainMenuState : GameState
{
    public MainMenuState()
    {
        SceneName = "MainMenu";
    }
}

public class CharacterCreationState : GameState
{
    public CharacterCreationState()
    {
        SceneName = "CharacterCreation";
    }
}

public class WorldState : GameState
{
    public WorldState()
    {
        SceneName = "World";
    }
}