using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Card : MonoBehaviour
{
    public SpriteRenderer backImage;
    public int CardIndex { get; private set; }
    public int Stage { get; private set; }
    public bool IsMatched { get; private set; }

    public void Initialize(int cardIndex, int stageNum)
    {
        Stage = stageNum;
        CardIndex = cardIndex;
        backImage.sprite = Resources.Load<Sprite>($"Stage{Stage}/img{CardIndex}");
    }
    
    public void SetMatched() // �׸� ��ġ Ȯ��
    {
        IsMatched = true;
    }


    public void WaitForSecondToFlip(float time)
    {
        if (!IsMatched) // �̹� ��Ī �Ϸ�� �̹����� �������� �ʴ´�
        {
            Invoke("Flip", time);
        }
    }

    public void Flip()
    {
        if (!IsMatched)
        {
            transform.Rotate(0, 180, 0);
        }
    }
}