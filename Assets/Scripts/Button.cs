using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Button : MonoBehaviour
{
    GameManager Instance;

    public string toScene; // 인스펙터로 씬 이름 입력하면 그 씬으로 이동.

    public int stage = 0;
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
        if (stage != 0) 
        { 
            Instance.stageNum = stage; // 인스펙터에서 stage 값 입력하면 그 값이 GameManager의 stageNum에 입력됨. stageNum을 활용해서 메인씬, 승리씬에 활용하면 될듯
        }
            
        Instance.LoadScene(toScene);
    }
}
