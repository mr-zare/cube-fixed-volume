using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    private TouchControls touchControls;
    private Vector2 startTouchPosition;
    private bool isTouching;
    private float touchableScreenWidth;

    [SerializeField]
    private float groundWidth;
    [SerializeField]
    private GameObject modelToScale;

    [SerializeField]
    private float maxWidth;
    private float area;
    private float witdh;
    private float height;
    private float startTouchHeight;
    private float xTarget;

    private void Awake()
    {
        Application.targetFrameRate = 120;
        touchControls = new TouchControls(); 
        touchableScreenWidth = Screen.width * 4/5;

        witdh = transform.position.y * 2;
        height = transform.position.y * 2;
        area = witdh * height;
    }
    private void OnEnable()
    {
        touchControls.Enable();
    }
    private void OnDisable()
    {
        touchControls.Disable();
    }
    private void Start()
    {
        touchControls.Touch.TouchPress.started += ctx => StartTouch(ctx);
        touchControls.Touch.TouchPress.canceled += ctx => EndTouch(ctx);
    }
    private void StartTouch(InputAction.CallbackContext context)
    {
        if(GameManager.instance.state != GameState.Play) { return; }

        isTouching = true;
        startTouchPosition = touchControls.Touch.TouchPosition.ReadValue<Vector2>();
        startTouchHeight = height;
    }
    private void EndTouch(InputAction.CallbackContext context)
    {
        isTouching = false;
    }
    private void Update()
    {
        if (isTouching)
        {
            Touching();
        }
    }
    private void Touching()
    {
        SetScale();
        CalculatePosition();
        SetPoeition();
    }
    private void SetScale()
    {
        Vector2 touchP = touchControls.Touch.TouchPosition.ReadValue<Vector2>();
        float deltaYRation = (touchP.y - startTouchPosition.y) / (touchableScreenWidth);
        deltaYRation = Mathf.Clamp(deltaYRation, -1, 1);
        float deltaHeight = deltaYRation * maxWidth;
        float newheigh = deltaHeight + startTouchHeight;
        height = Mathf.Clamp(newheigh, area / maxWidth, maxWidth);
        witdh = area / height;
        modelToScale.transform.localScale = new Vector3(witdh, height, modelToScale.transform.localScale.z);
    }
    private void CalculatePosition()
    {
        Vector2 touchP = touchControls.Touch.TouchPosition.ReadValue<Vector2>();
        float xRatio = (touchP.x - (Screen.width / 2)) / (touchableScreenWidth / 2);
        xRatio = Mathf.Clamp(xRatio, -1, 1);
        float x = xRatio * groundWidth / 2;
        xTarget = Mathf.Clamp(x, -(groundWidth - witdh) / 2, (groundWidth - witdh) / 2);
    }
    private void SetPoeition()
    {
        float x = Mathf.Lerp(transform.position.x, xTarget, 1 - Mathf.Pow((0.001f), Time.deltaTime));
        transform.position = new Vector3(x, height / 2, transform.position.z);
    }
}
