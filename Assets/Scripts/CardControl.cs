using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardControl : MonoBehaviour
{
    private List<Card> selectCards = new List<Card>();
    public int maxSelection = 2;

    public Action<Card[]> matcingCard;

    public void Initialize(int maxSelection)
    {
        this.maxSelection = maxSelection;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, Mathf.Infinity);
            if (hit)
            {
                if(hit.collider.TryGetComponent(out Card card))
                {
                    card.Flip();
                    SelectCard(card);
                }
            }
        }
    }

    public void SelectCard(Card card)
    {
        if(selectCards.Count == 2)
        {
            selectCards.Clear();
            selectCards.Add(card);
        }
        else selectCards.Add(card);

        if (selectCards.Count == 2) matcingCard?.Invoke(selectCards.ToArray());
    }
}
