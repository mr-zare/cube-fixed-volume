using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using MatchMasters.Managers.UI;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MenuController : MonoBehaviour,IPopupController
{
    private GameManager _gameManager;
    
    [SerializeField] private Button startBtn;
    [SerializeField] private Button creatorBtn;
    private UIEventManager _uiEventManager;
    [SerializeField] private GameObject creatorScene;
   // [SerializeField] private GameObject playScene;
    [SerializeField] private GameObject menuScene;

    private void Awake()
    {
        menuScene.SetActive(true);
    }

    void Start()
    {
    }
 
    void Update()
    {
        
    }

    public void OnEnterComplete()
    {
        _uiEventManager.SetButtonListener(startBtn,OnOpenStartGamePage);
        _uiEventManager.SetButtonListener(creatorBtn,OnOpenCreatorPopup);
    }

    public void OnOpenCreatorPopup()
    {
        GameManager.instance.UpdateGameState(GameState.Creator);
        creatorScene.SetActive(true);
    }

    public void OnOpenStartGamePage()
    {
        menuScene.SetActive(false);
        GameManager.instance.UpdateGameState(GameState.StartPage);
    }
    public void OnClose()
    {
    }

    public void OnCloseComplete()
    {
    }
}
