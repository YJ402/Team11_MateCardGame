using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEditor.Build.Player;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject obj = new GameObject(nameof(GameManager));
                _instance = obj.AddComponent<GameManager>();
                DontDestroyOnLoad(obj);
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }


    public int stage = 0; // 스테이지 선택 값을 저장. 에셋이미지 불러올때 활용

    public float bestScore = 0;
    public float currentScore = 0;
    PlayerPrefs playerPrefs;

    public float[] scores = new float[5];



    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    /*
    public void Score(string restTime)
    {
        currentScore = float.Parse(restTime);
        if(currentScore > score[4])
        {
            score[4] = currentScore;
            scores = scores.OrderBy(x => )

        }

    }
    */
}
