using System;
using System.Collections;
using System.Collections.Generic;
using MatchMasters.Managers.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class MapMove : MonoBehaviour
{
    [SerializeField] private Camera characterCamera;
    [SerializeField] private Vector3 transformPos;
    [SerializeField] private double factor;
    [SerializeField] private GameObject map;
    [SerializeField] private double speed;
    [SerializeField] private int vec11;
    [SerializeField] private int vec12;
    [SerializeField] private int vec21;
    [SerializeField] private int vec22;
    [SerializeField] private int finall;
    [SerializeField] private bool isdo1;
    [SerializeField] private bool isdo2;
    [SerializeField] private GameObject winScene; 
    [SerializeField] private GameObject playScene;

    private GameManager _gameManager;
    void Start()
    {
        _gameManager = GameManager.instance;
    }

    void Update()
    {
        if (map.transform.position.z < finall )
        {
            speed = 0;
            _gameManager.UpdateGameState(GameState.Win);
            winScene.SetActive(true);
            playScene.SetActive(false);
        }
        if (GameManager.instance.state == GameState.Play)
        {
            Move();
        }
    }
    private void Move()
    {
        if (map.transform.position.z < vec11 && map.transform.position.z > vec12 && isdo1 == false)
        {
            isdo1 = true;
            speed += factor;
        }
        if (map.transform.position.z < vec21 && map.transform.position.z > vec22 && isdo2 == false)
        {
            isdo2 = true;
            speed += factor;
        }
        transformPos = map.transform.position;
        transformPos.z = (float)(transformPos.z - speed * Time.deltaTime);
        map.transform.position = transformPos;
    }
}
