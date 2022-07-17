using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [HideInInspector]
    public GameState state;

    public static event Action<GameState> OnGameStateChange;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void Start()
    {
        UpdateGameState(GameState.Play);
    }
    public void UpdateGameState(GameState newState)
    {
        state = newState;

        switch (newState)
        {
            case GameState.Menu:
                break;
            case GameState.Play:
                break;
            case GameState.stop:
                break;
            case GameState.Win:
                break;
            case GameState.Lose:
                Debug.Log("lose");
                break;
            default:
                break;
        }

        OnGameStateChange?.Invoke(newState);
    }
}
public enum GameState
{
    Menu,
    Play,
    stop,
    Win,
    Lose
}