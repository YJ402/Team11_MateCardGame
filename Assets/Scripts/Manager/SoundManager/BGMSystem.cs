using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMSystem : SoundSystem
{
    public override AudioSource GetAudioSource()
    {
        AudioSource audio = base.GetAudioSource();
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

    IEnumerator PlaySound(AudioSource audio)
    {
        yield return new WaitForSeconds(audio.clip.length);

        audioSources.Remove(audio);
        poolManager.ReturnObject(audio);
    }
}
