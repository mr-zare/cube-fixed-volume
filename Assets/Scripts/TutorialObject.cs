using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialObject : MonoBehaviour
{
    [SerializeField]
    private GameObject canvas;
    [SerializeField]
    private float time;
    private void OnTriggerEnter(Collider other)
    {
        if (!TutorialManager.ShwoTutorial)
        {
            return;
        }
        if(other.tag == "Player")
        {
            Debug.Log("tutorial");
            canvas.SetActive(true);
            MapMove.instance.SpeedTutorial();
            Invoke("Hide", time);
        }
    }
    private void Hide()
    {
        canvas.SetActive(false);
        MapMove.instance.SpeedTutorial();
    }
}
