using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    private PoolManager poolManager;

    private List<AudioSource> audioSources = new List<AudioSource>();

    public void Initialize(GameManager manager)
    {
        poolManager = manager.PoolManager;
    }

    public void StopAllSounds()
    {
        for (int i = 0; i < audioSources.Count; i++)
        {
            audioSources[i].Stop();
            poolManager.ReturnObject(audioSources[i]);
        }
    }

    public AudioSource GetAudioSource()
    {
        AudioSource audio = poolManager.GetAvailableObject<AudioSource>();
        audio.pitch = 1;
        audio.volume = 1;
        audio.loop = false;

        return audio;
    }

    public void OnPlayLoop(AudioClip clip)
    {
        AudioSource audio = GetAudioSource();
        audioSources.Add(audio);

        audio.clip = clip;
        audio.loop = true;
        audio.Play();
    }

    public void OnPlaySound(AudioClip clip)
    {
        AudioSource audio = GetAudioSource();
        audioSources.Add(audio);

        audio.clip = clip;
        audio.Play();

        StartCoroutine(PlaySound(audio));
    }

    public void OnPlaySound(AudioClip clip, float volume)
    {
        AudioSource audio = GetAudioSource();
        audioSources.Add(audio);

        audio.clip = clip;
        audio.volume = volume;
        audio.Play();

        StartCoroutine(PlaySound(audio));
    }

    public void OnPlaySound(AudioClip clip, float volume, float pitch)
    {
        AudioSource audio = GetAudioSource();
        audioSources.Add(audio);

        audio.clip = clip;
        audio.volume = volume;
        audio.pitch = pitch;
        audio.Play();

        StartCoroutine(PlaySound(audio));
    }

    IEnumerator PlaySound(AudioSource audio)
    {
        yield return new WaitForSeconds(audio.clip.length);

        audioSources.Remove(audio);
        poolManager.ReturnObject(audio);
    }
}
