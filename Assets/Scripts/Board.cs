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

        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 }; // 배열 선언
        arr = arr.OrderBy(x => Random.Range(0f, 7f)).ToArray(); // 선언한 배열을 랜덤하게 섞어 정렬한다.

        for (int i = 0; i < 16; i++)
        {
            float x = (i % 4) * margin - 1.6f;
            float y = (i / 4) * margin - 1.7f;

            Card card = Instantiate(cardPrefab, new Vector3(x, y, 0), Quaternion.identity);

            cards.Add(card);

            card.transform.position = new Vector3(x, y, 0);
            card.GetComponent<Card>().Initialize(arr[i]); // 좌측 하단부터 차례대로 생성되는 카드에 배열에 저장된 숫자를 부여한다.
        }

        /*
        for (int x = 0; x < boardSize; x++)
        {
            for(int y = 0; y < boardSize; y++)
            {
                Card card = Instantiate(cardPrefab, new Vector3(x - 1.5f, y - 1.7f, 0) * margin, Quaternion.identity);
                card.Initialize(Random.Range(0, 6));
                cards.Add(card);
            }
        }
        */
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
