using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Button : MonoBehaviour
{
    GameManager Instance;
    public string toScene;

    // Start is called before the first frame update
    void Start()
    {
        Instance = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        Instance.LoadScene(toScene);
    }
}
