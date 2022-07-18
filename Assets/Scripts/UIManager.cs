using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text countDown;
    private int count;
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

        }
    }
    public void StopButton()
    {
        GameState state = GameManager.instance.state;
        if (state == GameState.Play)
        {
            GameManager.instance.UpdateGameState(GameState.stop);
        }
        else if (state == GameState.stop)
        {
            GameManager.instance.UpdateGameState(GameState.Play);
        }
    }
    public void StartButton()
    {
        GameManager.instance.UpdateGameState(GameState.starting);

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
