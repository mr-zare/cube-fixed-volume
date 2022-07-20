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
    [SerializeField] private double tutorialFactor;
    [SerializeField] private GameObject map;
    [SerializeField] private double speed;
    [SerializeField] private int vec11;
    [SerializeField] private int vec12;
    [SerializeField] private int vec21;
    [SerializeField] private int vec22;
    [SerializeField] private int finall;
    [SerializeField] private bool isdo1;
    [SerializeField] private bool isdo2;
    [SerializeField] private bool isdo3; 
    //[SerializeField] private GameObject winScene; 
    //[SerializeField] private GameObject playScene;

    private Vector3 startPosition;

    private GameManager _gameManager;
    private void Awake()
    {
        GameManager.OnGameStateChange += onGameStateChange;
    }
    private void OnDisable()
    {
        GameManager.OnGameStateChange -= onGameStateChange;
    }
    void onGameStateChange(GameState state)
    {
        if (state == GameState.Menu)
        {
            reset();
        }
    }
    void Start()
    {
        _gameManager = GameManager.instance;
        startPosition = map.transform.position;
    }

    void Update()
    {
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

    private void SpeedTutorial()
    {
        if (isdo3 == false)
        {
            isdo3 = true;
            speed *= tutorialFactor;
        }
        else
        {
            isdo3 = false;
            speed /= tutorialFactor;
        }
    }
    private void reset()
    {
        map.transform.position = startPosition;
    }
}
