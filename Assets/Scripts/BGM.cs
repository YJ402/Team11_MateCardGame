using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public AudioClip Stage1;
    public AudioClip Stage3;
    public AudioClip Stage5;
    GameManager GM;
    private SoundManager sound;
    private AudioSource audiosource;

    public void Start()
    {
        audiosource = GetComponent<AudioSource>();
        GM = GameManager.Instance;
        if (audiosource == null)
        {
            audiosource = gameObject.AddComponent<AudioSource>();
        }
        stage_type();
    }
 
       public void stage_type()
    {
        AudioClip selectedClip = null;

        switch (GameManager.Instance.stageNum)
        {
            case 1:
                selectedClip = Stage1;
                break;
            case 3:
                selectedClip = Stage3;
                break;
            case 5:
                selectedClip = Stage5;
                break;
            default:
                Debug.LogWarning("No matching stage found for stageNum: " + GameManager.Instance.stageNum);
                return;
        }

        // Clip 설정 및 재생
        if (selectedClip != null)
        {
            audiosource.clip = selectedClip;
            audiosource.Play();
        }
    }
}
