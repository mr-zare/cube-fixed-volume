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
    [SerializeField]
    private GameObject winPanel;
    [SerializeField]
    private GameObject[] hearts;
    [SerializeField]
    private Image[] SoundButtonIcon;
    [SerializeField]
    private Sprite[] SoundIconSprites;
    private void Awake()
    {
        GameManager.OnGameStateChange += onGameStateChange;
        GameManager.OnHeartLost += OnHeartLost;
    }
    private void OnDisable()
    {
        GameManager.OnGameStateChange -= onGameStateChange;
        GameManager.OnHeartLost -= OnHeartLost;
    }
    void onGameStateChange(GameState state)
    {
        if(state == GameState.Lose)
        {
            LosePanel.SetActive(true);
        }
        if (state == GameState.Win)
        {
            winPanel.SetActive(true);
        }
        if (state == GameState.Menu)
        {
            startButton.SetActive(true);
            foreach (GameObject item in hearts)
            {
                item.SetActive(true);
            }
        }
    }
    private void Start()
    {
        SoundButton();
    }
    private void OnHeartLost(int heartsCount)
    {
        hearts[heartsCount].SetActive(false);
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
    public void SoundButton()
    {
        foreach (Image item in SoundButtonIcon)
        {
            if (AudioManager.MusicSetting)
            {
                item.sprite = SoundIconSprites[0];
            }
            else
            {
                item.sprite = SoundIconSprites[1];
            }
        }
    }
}
