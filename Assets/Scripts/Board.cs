using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Board : MonoBehaviour
{
    public int boardSize = 4;

    public HashSet<Card> cards = new HashSet<Card>();
    public Card cardPrefab;

    public float margin = 1.1f;

    private GameManager gameManager;
    private CardControl cardControl;

    private void Start()
    {
        gameManager = GameManager.Instance;
        cardControl = GetComponentInChildren<CardControl>();

        Initialize();
    }

    private void Initialize()
    {
        cardControl.matcingCard += CheckMatching;

        for(int x = 0; x < boardSize; x++)
        {
            for(int y = 0; y < boardSize; y++)
            {
                Card card = Instantiate(cardPrefab, new Vector3(x, y, 0) * margin, Quaternion.identity);
                card.Initialize(Random.Range(0, 6));
                cards.Add(card);
            }
        }
    }

    private void Update()
    {

    }

    private void CheckMatching(Card[] cards)
    {
        if (cards[0].CardIndex == cards[1].CardIndex)
        {
            Debug.Log("Succes Card Matching.");
        }
        else
        {
            for(int i = 0; i < cards.Length; i++)
            {
                Debug.Log("test");
                Card card = cards[i];
                card.WaitForSecondToFlip(1);
            }
        }
    }
}
