using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Button : MonoBehaviour
{
    private GameManager Instance;

    public string toScene; // ï¿½Î½ï¿½ï¿½ï¿½ï¿½Í·ï¿½ ï¿½ï¿½ ï¿½Ì¸ï¿½ ï¿½Ô·ï¿½ï¿½Ï¸ï¿½ ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½Ìµï¿½.

    public int stage = 0;

    public float delay = 0;

    // Start is called before the first frame update
    void Start()
    {
        Instance = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(delay);

        if (stage != 0) 
        { 
            if(stage == -1)
            {
                Instance.stageNum = Random.Range(1, 7);
            }
            else Instance.stageNum = stage; // ÀÎ½ºÆåÅÍ¿¡¼­ stage °ª ÀÔ·ÂÇÏ¸é ±× °ªÀÌ GameManagerÀÇ stageNum¿¡ ÀÔ·ÂµÊ. stageNumÀ» È°¿ëÇØ¼­ ¸ÞÀÎ¾À, ½Â¸®¾À¿¡ È°¿ëÇÏ¸é µÉµí
        }
        Debug.Log(Instance.stageNum);

        Instance.LoadScene(toScene);
    }

    public void OnClick()
    {
        StartCoroutine(Delay());
    }

    public void PlaySound(AudioClip clip)
    {
        GameManager.Instance.SoundManager.PlaySound(clip);
    }
}
