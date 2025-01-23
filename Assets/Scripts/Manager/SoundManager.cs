using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public SFXManager SFXManager { get; private set; }
    //public BGMManager BGMManager { get; private set; }

    private AudioSource audioSource;

    public void Initialize(GameManager manager)
    {
        SFXManager = GetComponentInChildren<SFXManager>();
        SFXManager.Initialize(manager);
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void OnStopAllSounds()
    {
        SFXManager.StopAllSounds();
    }
}