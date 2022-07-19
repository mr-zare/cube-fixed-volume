using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using MatchMasters.Managers.UI;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class LoseSceneController : MonoBehaviour,IPopupController
{
    //[SerializeField] private Button restartBtn;
    //[SerializeField] private Button menuBtn;
    //private GameManager _gameManager;
    //private UIEventManager _uiEventManager;
    [SerializeField] private GameObject looseScene;
    [SerializeField] private GameObject menuScene;

    private void Awake()
    {
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnEnterComplete()
    {
        //_uiEventManager.SetButtonListener(restartBtn,OnOpenPlayScene);
        //_uiEventManager.SetButtonListener(menuBtn,OnOpenMenuScene);
    }

    public void OnOpenMenuScene()
    {
        GameManager.instance.UpdateGameState(GameState.Menu);
        menuScene.SetActive(true);
        looseScene.SetActive(false);
    }
    public void OnRestartGame()
    {
        GameManager.instance.UpdateGameState(GameState.Menu);
        looseScene.SetActive(false);
    }
    public void OnClose()
    {
    }

    public void OnCloseComplete()
    {
    }
}
