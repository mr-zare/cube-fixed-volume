using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.instance.state == GameState.Play)
        {
            if (other.tag == "Obstacles")
            {
                GameManager.instance.UpdateGameState(GameState.Lose);
            }
            if (other.tag == "FinishLine")
            {
                GameManager.instance.UpdateGameState(GameState.Win);
            }
        }
    }
}
