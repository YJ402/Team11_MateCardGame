using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Button : MonoBehaviour
{
    private GameManager Instance;

    public string toScene; // �ν����ͷ� �� �̸� �Է��ϸ� �� ������ �̵�.

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
            Instance.stageNum = stage; // �ν����Ϳ��� stage �� �Է��ϸ� �� ���� GameManager�� stageNum�� �Էµ�. stageNum�� Ȱ���ؼ� ���ξ�, �¸����� Ȱ���ϸ� �ɵ�
        if (stage != 0) 
        { 
            if(stage == -1)
            {
                Instance.stageNum = Random.Range(1, 7);
            }
            else Instance.stageNum = stage; // �ν����Ϳ��� stage �� �Է��ϸ� �� ���� GameManager�� stageNum�� �Էµ�. stageNum�� Ȱ���ؼ� ���ξ�, �¸����� Ȱ���ϸ� �ɵ�
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
