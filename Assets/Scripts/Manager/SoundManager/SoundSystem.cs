using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SoundSystem : MonoBehaviour
{
    protected PoolManager poolManager;

    protected List<AudioSource> audioSources = new List<AudioSource>();

    public virtual void Initialize(GameManager manager)
    {
        poolManager = manager.PoolManager;
    }

    public virtual void StopAllSounds()
    {
        for (int i = 0; i < audioSources.Count; i++)
        {
            audioSources[i].Stop();
            poolManager.ReturnObject(audioSources[i]);
        }
    }

    public virtual AudioSource GetAudioSource()
    {
        AudioSource audio = poolManager.GetAvailableObject<AudioSource>();
        audio.pitch = 1;
        audio.volume = 1;

        return audio;
    }

    public void OnPlaySound(AudioClip clip)
    {
        AudioSource audio = GetAudioSource();
        audioSources.Add(audio);

        audio.clip = clip;
        audio.Play();

        StartCoroutine(ReturnAudio(audio));
    }

    public void OnPlaySound(AudioClip clip, float volume)
    {
        AudioSource audio = GetAudioSource();
        audioSources.Add(audio);

        audio.clip = clip;
        audio.volume = volume;
        audio.Play();

        StartCoroutine(ReturnAudio(audio));
    }

    public void OnPlaySound(AudioClip clip, float volume, float pitch)
    {
        AudioSource audio = GetAudioSource();
        audioSources.Add(audio);

        audio.clip = clip;
        audio.volume = volume;
        audio.pitch = pitch;
        audio.Play();

        StartCoroutine(ReturnAudio(audio));
    }

    IEnumerator ReturnAudio(AudioSource audio)
    {
        yield return new WaitForSeconds(audio.clip.length);

        audioSources.Remove(audio);
        poolManager.ReturnObject(audio);
    }
}
