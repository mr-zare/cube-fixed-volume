using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.instance.state == GameState.Play)
        {
            if (other.tag == "obstacles")
            {
                GameManager.instance.UpdateGameState(GameState.Lose);
            }
            if (other.tag == "finishLine")
            {
                GameManager.instance.UpdateGameState(GameState.Win);
            }
        }
    }
}
