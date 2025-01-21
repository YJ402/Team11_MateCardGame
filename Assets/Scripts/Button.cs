using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Button : MonoBehaviour
{
    GameManager Instance;

    public string toScene; // �ν����ͷ� �� �̸� �Է��ϸ� �� ������ �̵�.

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
            Instance.stageNum = stage; // �ν����Ϳ��� stage �� �Է��ϸ� �� ���� GameManager�� stageNum�� �Էµ�. stageNum�� Ȱ���ؼ� ���ξ�, �¸����� Ȱ���ϸ� �ɵ�
        }
            
        Instance.LoadScene(toScene);
    }
}
