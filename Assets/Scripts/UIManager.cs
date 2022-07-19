using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject startButton;
    [SerializeField]
    private Text countDown;
    private int count;
    [SerializeField]
    private Image pasueButtonImage;
    [SerializeField]
    private Sprite stopImage;
    [SerializeField]
    private Sprite startImaeg;
    [SerializeField]
    private GameObject LosePanel;
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
        if(state == GameState.Lose)
        {
            LosePanel.SetActive(true);
        }
        if (state == GameState.Menu)
        {
            startButton.SetActive(true);
        }
    }
    public void StopButton()
    {
        GameState state = GameManager.instance.state;
        if (state == GameState.Play)
        {
            pasueButtonImage.sprite = startImaeg;
            GameManager.instance.UpdateGameState(GameState.stop);
        }
        else if (state == GameState.stop)
        {
            pasueButtonImage.sprite = stopImage;
            GameManager.instance.UpdateGameState(GameState.Play);
        }
    }
    public void StartButton()
    {
        GameManager.instance.UpdateGameState(GameState.starting);

        countDown.text = "3";
        count = 3;
        countDown.gameObject.SetActive(true);
        Invoke("UpdateCountDown", 1);
        Invoke("UpdateCountDown", 2);
        Invoke("UpdateCountDown", 3);
        Invoke("UpdateCountDown", 4);
    }
    private void UpdateCountDown()
    {
        count -= 1;

        if(count == 0)
        {
            countDown.text = "GO !!!";
            GameManager.instance.UpdateGameState(GameState.Play);
            return;
        }
        else if (count <= 0)
        {
            countDown.gameObject.SetActive(false);
            return;
        }

        countDown.text = count.ToString();
    }
}
