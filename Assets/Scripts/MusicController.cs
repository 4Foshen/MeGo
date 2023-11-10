using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private AudioSource music;
    private bool isMusicOn;

    private void Awake()
    {
        music = GetComponent<AudioSource>();
    }
    private void Start()
    {
        isMusicOn = PlayerPrefs.GetInt("Music", 1) == 1;
        ToogleMusic();
    }

    private void ToogleMusic()
    {
        if (isMusicOn) music.enabled = true;
        else music.enabled = false;
    }
}
