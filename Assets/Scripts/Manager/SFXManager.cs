using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    private PoolManager poolManager;

    private List<AudioSource> audioSources = new List<AudioSource>();

    public void Initialize(GameManager manager)
    {
        poolManager = manager.PoolManager;
    }

    public void StopAllSounds()
    {
        for(int i = 0; i < audioSources.Count; i++)
        {
            audioSources[i].Stop();
        }
    }

    public void OnPlaySound(AudioClip clip)
    {
        AudioSource audio = poolManager.GetAvailableObject<AudioSource>();
        audioSources.Add(audio);

        audio.clip = clip;
        audio.Play();

        StartCoroutine(PlaySound(audio));
    }

    IEnumerator PlaySound(AudioSource audio)
    {
        yield return new WaitForSeconds(audio.clip.length);

        poolManager.ReturnObject(audio);
    }
}
