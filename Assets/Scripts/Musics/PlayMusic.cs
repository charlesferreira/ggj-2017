﻿using UnityEngine;
using System.Collections;

public class PlayMusic : MonoBehaviour {

    public AudioSource introMusic;
    public AudioSource gameMusic;

    static PlayMusic instance;
    public static PlayMusic Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<PlayMusic>();
            return instance;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void PlayIntroMusic()
    {
        gameMusic.Stop();
        introMusic.Play();
    }

    public void PlayGameMusic()
    {
        introMusic.Stop();
        gameMusic.Play();
    }
}
