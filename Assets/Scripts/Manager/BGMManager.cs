using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public AudioClip Stage1;
    public AudioClip Stage2;
    public AudioClip Stage3;
    public AudioClip Stage4;
    public AudioClip Stage5;
    private AudioSource audiosource;
    private GameManager GM;


    void Start()
    {
        GM = GameManager.Instance;
        audiosource = GetComponent<AudioSource>();
        stage_BGM();
    }
    private void stage_BGM ()
    {
        AudioClip clip = null;

        switch(GM.stageNum)
        {
            case 1: clip = Stage1; break;
            case 2: clip = Stage2; break;
            case 3: clip = Stage3; break;
            case 4: clip = Stage4; break;
            case 5: clip = Stage5; break;
        }
        if(clip != null)
        {
            audiosource.clip = clip;
            audiosource.Play();
        }

    }
}
