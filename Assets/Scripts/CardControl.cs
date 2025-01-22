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
        if (card.IsMatched) // �̹� ��Ī�� ī��� Ŭ�� �Ұ�
        {
            return;
        }

        var collider = card.GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.enabled = false; // ī�� ���� Ŭ�� ����
        }

        selectCards.Add(card);

        if (selectCards.Count == maxSelection)
        {
            matcingCard?.Invoke(selectCards.ToArray());

            var firstCardCollider = selectCards[0].GetComponent<Collider2D>();
            if (firstCardCollider != null)
            {
                firstCardCollider.enabled = true; // ù ��° ī�� �ٽ� Ȱ��ȭ
            }
            var secondCardCollider = selectCards[1].GetComponent<Collider2D>();
            if (secondCardCollider != null)
            {
                secondCardCollider.enabled = true; // �� ��° ī�� �ٽ� Ȱ��ȭ
            }

            if (!selectCards[0].IsMatched)
                selectCards[0].GetComponent<Shadow>().Activation();
            if (!selectCards[1].IsMatched)
                selectCards[1].GetComponent<Shadow>().Activation();

            // ���� ī�� �ʱ�ȭ
            selectCards.Clear();
        }
    }
}