using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using MatchMasters.Managers.UI;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Menucontroller : MonoBehaviour,IPopupController
{
    private GameManager _gameManager;
    
    [SerializeField] private Button startBtn;
    [SerializeField] private Button creatorBtn;
    private UIEventManager _uiEventManager;
    [SerializeField] private GameObject creatorScene;
    [SerializeField] private GameObject playScene;
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

    private void OnOpenCreatorPopup()
    {
        _gameManager.UpdateGameState(GameState.Creator);
        menuScene.SetActive(false);
        creatorScene.SetActive(true);
    }

    private void OnOpenStartGamePage()
    {
        _gameManager.UpdateGameState(GameState.Play);
        playScene.SetActive(true);
        menuScene.SetActive(false);
    }
    public void OnClose()
    {
    }

    public void OnCloseComplete()
    {
    }
}
