using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;
   
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void StopAllSound()
    {
        audioSource.Stop();
    }
}
