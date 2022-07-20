using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private Sound[] sounds;

    public static bool MusicSetting;

    private void Awake()
    {
        foreach (Sound item in sounds)
        {
            item.source =gameObject.AddComponent<AudioSource>();
            item.source.clip = item.clip;

            item.source.volume = item.volume;
            item.source.pitch = item.pitch;
            item.source.loop = item.loop;
        }

        if (!PlayerPrefs.HasKey("MusicSetting"))
        {
            PlayerPrefs.SetInt("MusicSetting", 1);
        }

        MusicSetting = PlayerPrefs.GetInt("MusicSetting") == 1;
    }
    private void OnEnable()
    {
        GameManager.OnGameStateChange += onGameStateChange;
        GameManager.OnHeartLost += OnHeartLost;
    }
    private void OnDisable()
    {
        GameManager.OnGameStateChange -= onGameStateChange;
        GameManager.OnHeartLost -= OnHeartLost;
    }
    private void Play(string name)
    {
        if (!MusicSetting)
        {
            return;
        }
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            return;
        }
        s.source.Play();
    }
    private void onGameStateChange(GameState state)
    {
        if(state == GameState.Win)
        {
            Play("Win");
        }
    }
    private void OnHeartLost(int h)
    {
        Play("Ouch");
    }
    private void Start()
    {
        Play("Background");
    }
    public void SoundButton()
    {
        if (MusicSetting)
        {
            MusicSetting = false;
            PlayerPrefs.SetInt("MusicSetting", 0);

            foreach (Sound item in sounds)
            {
                item.source.Stop();
            }
        }
        else
        {
            MusicSetting = true;
            PlayerPrefs.SetInt("MusicSetting", 1);
            Play("Background");
        }
    }
}  