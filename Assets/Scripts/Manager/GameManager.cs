using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
                GameObject prefab = Resources.Load<GameObject>("Prefabs/GameManager");
                if (prefab != null)
                {
                    GameObject obj = Instantiate(prefab);
                    _instance = obj.GetComponent<GameManager>();
                    _instance.Initialize();
                }
                else Debug.LogError("GameManager Not Found");
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

        Initialize();
    }

    public PoolManager PoolManager { get; private set; }
    public SoundManager SoundManager { get; private set; }

    public int stageNum = 0;

    public void Initialize()
    {
        PoolManager = GetComponentInChildren<PoolManager>();

        

        SoundManager = GetComponentInChildren<SoundManager>();
        SoundManager.Initialize(this);
    }

    public void LoadScene(string name)
    {
        SoundManager.OnStopAllSounds();
        SceneManager.LoadScene(name);
    }
}