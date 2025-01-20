using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void Initialize()
    {

    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;

        Initialize();

        DontDestroyOnLoad(gameObject);
    }
}
