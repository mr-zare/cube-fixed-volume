using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    [SerializeField] private bool isdo1;
    [SerializeField] private bool isdo2;



    void Start()
    {
        
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
}
