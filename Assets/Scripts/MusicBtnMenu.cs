using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using MatchMasters.Managers.UI;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MusicBtnMenu : MonoBehaviour, IPopupController
{
    private GameManager _gameManager;
    [SerializeField] private Button musicBtn;
    private UIEventManager _uiEventManager;


    public void OnEnterComplete()
    {
        //_uiEventManager.SetButtonListener(musicBtn,Onhandlemusic);

    }

    private void Onhandlemusic()
    {
        //handle music   
    }


    public void OnClose()
    {
    }

    public void OnCloseComplete()
    {
    }
}
