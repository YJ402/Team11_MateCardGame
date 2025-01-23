using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSFX : MonoBehaviour
{
    private SoundManager soundManager;

    public void Start()
    {
        soundManager = GameManager.Instance.SoundManager;
    }

    public void OnPlaySFX(AudioClip clip)
    {
        soundManager.SFXManager.OnPlaySound(clip);
    }
}
