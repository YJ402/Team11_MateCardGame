using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSFX : MonoBehaviour
{
    public AudioClip fallingSFX;
    public AudioClip MoveCloudSFX;
    public AudioClip MoveDownSFX;
    public AudioClip MoveUpSFX;

    private SoundManager soundManager;

    public void Start()
    {
        soundManager = GameManager.Instance.SoundManager;
    }

    public void OnPlayFallingSFX()
    {
        soundManager.PlaySound(fallingSFX);
    }

    public void OnPlayMoveCloudSFX()
    {
        soundManager.PlaySound(MoveCloudSFX);
    }

    public void OnPlayMoveDownSFX()
    {
        soundManager.PlaySound(MoveDownSFX);
    }

    public void OnPlayMoveUpSFX()
    {
        soundManager.PlaySound(MoveUpSFX);
    }
}
