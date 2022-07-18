using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using MatchMasters.Managers.UI;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CreatorPopup : MonoBehaviour,IPopupController
{
    [SerializeField] private Button close;
    private UIEventManager _uiEventManager;
    private GameManager _gameManager;
    [SerializeField] private GameObject creatorScene;

    private void Awake()
    {
        creatorScene.SetActive(true);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnEnterComplete()
    {
        _uiEventManager.SetButtonListener(close,OnOpenMenu);
    }

    private void OnOpenMenu()
    {
        _gameManager.UpdateGameState(GameState.Menu);
        creatorScene.SetActive(false);
    }

    public void OnClose()
    {
    }

    public void OnCloseComplete()
    {
    }
}
