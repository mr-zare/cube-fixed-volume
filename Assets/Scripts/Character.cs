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

    public float groundWidth;
    public GameObject modelToScale;

    public float maxWidth;
    private float area;
    private float witdh;
    private float height;
    private float startTouchHeight;

    private void Awake()
    {
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
        isTouching = true;
        startTouchPosition = touchControls.Touch.TouchPosition.ReadValue<Vector2>();
        startTouchHeight = height;
    }
    private void EndTouch(InputAction.CallbackContext context)
    {
        isTouching = false;
        startTouchPosition = touchControls.Touch.TouchPosition.ReadValue<Vector2>();
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
        SetPosition();
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
    private void SetPosition()
    {
        Vector2 touchP = touchControls.Touch.TouchPosition.ReadValue<Vector2>();
        float xRatio = (touchP.x - (Screen.width / 2)) / (touchableScreenWidth / 2);
        xRatio = Mathf.Clamp(xRatio, -1, 1);
        float x = xRatio * groundWidth / 2;
        x = Mathf.Clamp(x, -(groundWidth - witdh) / 2, (groundWidth - witdh) / 2);
        transform.position = new Vector3(x, height / 2, transform.position.z);
    }
}
