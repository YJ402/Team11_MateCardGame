using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Card : MonoBehaviour
{
    public SpriteRenderer sprite;
    public TextMeshPro index;
    public int CardIndex { get; private set; }

    public void Initialize(int cardIndex)
    {
        CardIndex = cardIndex;
        index.text = cardIndex.ToString();
    }

    public void Awake()
    {
        
    }

    public void WaitForSecondToFlip(float time)
    {
        Invoke("Flip", time);
    }

    public void Flip()
    {
        transform.Rotate(0, 180, 0);
    }
}
