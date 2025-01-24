using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public SFXSystem SFXManager { get; private set; }
    public BGMSystem BGMManager { get; private set; }

    public AudioSource audioSource;

    public void Initialize(GameManager manager)
    {
        SFXManager = GetComponentInChildren<SFXSystem>();
        SFXManager.Initialize(manager);

        BGMManager = GetComponentInChildren<BGMSystem>();
        BGMManager.Initialize(manager);
    }

    public void OnStopAllSounds()
    {
        SFXManager.StopAllSounds();
        BGMManager.StopAllSounds();
    }
}