using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StageManager : MonoBehaviour
{
    public static StageManager sMng;
    private int stg = 0;
    private void Awake()
    {
        if (sMng == null)
        {
            sMng = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void GoToTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
    public void GoToSelect()
    {
        SceneManager.LoadScene("SelectScene");
    }
    public void GoToStage(int stage)
    {
        stg = stage;
        SceneManager.LoadScene("MainScene");
    }
    public void GoToSuccess()
    {
        SceneManager.LoadScene("SuccessScene");
    }
    public void GoToFail()
    {
        SceneManager.LoadScene("FailScene");
    }

    public void Retry()
    {
        SceneManager.LoadScene("MainScene");
    }

    public int stageNum() //MainScene에 스테이지 제공을 위해
    {
        return stg;
    }
}
