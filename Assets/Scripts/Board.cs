using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class Board : MonoBehaviour
{
    public int boardSize = 4;

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

        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 }; // �迭 ����
        arr = arr.OrderBy(x => Random.Range(0f, 7f)).ToArray(); // ������ �迭�� �����ϰ� ���� �����Ѵ�.

        for (int i = 0; i < boardSize * boardSize; i++)
        {
            float x = (i % boardSize) * margin - 1.6f;
            float y = (i / boardSize) * margin - 1.7f;

            Card card = Instantiate(cardPrefab, new Vector3(x, y, 0), Quaternion.identity);
            card.Initialize(arr[i]); // ���� �ϴܺ��� ���ʴ�� �����Ǵ� ī�忡 �迭�� ����� ���ڸ� �ο��Ѵ�.
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
