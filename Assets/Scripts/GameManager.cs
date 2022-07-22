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
    public static event Action OnCollision;
    public static event Action<int> OnHeartLost;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void Start()
    {
        UpdateGameState(GameState.Menu);
    }
    public void UpdateGameState(GameState newState)
    {
        state = newState;
        Debug.Log(newState);

        switch (newState)
        {
            case GameState.Menu:
                break;
            case GameState.StartPage:
                break;
            case GameState.starting:
                break;
            case GameState.Play:
                break;
            case GameState.stop:
                break;
            case GameState.Win:
                break;
            case GameState.Lose:
                break;
            case GameState.Creator:
                break;
            default:
                break;
        }

        OnGameStateChange?.Invoke(newState);
    }
    public void Collide()
    {
        OnCollision?.Invoke();
    }
    public void LoseHeart(int hearts)
    {
        OnHeartLost?.Invoke(hearts);
    }
}
public enum GameState
{
    Menu,
    StartPage,
    starting,
    Play,
    stop,
    Win,
    Lose,
    Creator
}