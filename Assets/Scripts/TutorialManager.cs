using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    private bool ShwoTutorial;
    [SerializeField]
    private GameObject tutorialPage;
    [SerializeField]
    private float tutorialTime;
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Tutorial"))
        {
            PlayerPrefs.SetInt("Tutorial", 0);
        }

        ShwoTutorial = PlayerPrefs.GetInt("Tutorial") == 0;
        PlayerPrefs.SetInt("Tutorial", 1);
    }
    private void OnEnable()
    {
        GameManager.OnGameStateChange += onGameStateChange;
    }
    private void OnDisable()
    {
        GameManager.OnGameStateChange -= onGameStateChange;
    }
    private void onGameStateChange(GameState state)
    {
        if(state == GameState.Play)
        {
            Invoke("HideFirstTutorial", tutorialTime);
        }
        if (state == GameState.Win)
        {
            ShwoTutorial = false;
        }
        if (state == GameState.Lose)
        {
            ShwoTutorial = false;
        }
    }
    private void Start()
    {
        if (ShwoTutorial) 
        {
            ShowFirstTutorial(); 
        }
    }
    private void ShowFirstTutorial()
    {
        tutorialPage.SetActive(true);
    }
    private void HideFirstTutorial()
    {
        tutorialPage.SetActive(false);
    }
}
