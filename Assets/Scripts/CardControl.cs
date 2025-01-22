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

                    card.GetComponent<Shadow>().Deactivation();
                    card.Flip();
                    SelectCard(card);

                }
            }
        }
    }

    public void SelectCard(Card card)
    {
        if (card.IsMatched) // 이미 매칭된 카드는 클릭 불가
        {
            return;
        }

        var collider = card.GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.enabled = false; // 카드 더블 클릭 방지
        }

        selectCards.Add(card);

        if (selectCards.Count == maxSelection)
        {
            matcingCard?.Invoke(selectCards.ToArray());

            var firstCardCollider = selectCards[0].GetComponent<Collider2D>();
            if (firstCardCollider != null)
            {
                firstCardCollider.enabled = true; // 첫 번째 카드 다시 활성화
            }
            var secondCardCollider = selectCards[1].GetComponent<Collider2D>();
            if (secondCardCollider != null)
            {
                secondCardCollider.enabled = true; // 두 번째 카드 다시 활성화
            }

            if (!selectCards[0].IsMatched)
                selectCards[0].GetComponent<Shadow>().Activation();
            if (!selectCards[1].IsMatched)
                selectCards[1].GetComponent<Shadow>().Activation();

            // 선택 카드 초기화
            selectCards.Clear();
        }
    }
}