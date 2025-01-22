using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    public int boardSize = 4;

    public Card cardPrefab;

    public float margin = 1.1f;
    public Text timeTxt;

    public int cardCount = 0;
    float time = 0.0f;


    private GameManager gameManager;
    private CardControl cardControl;

    private void Start()
    {
        Time.timeScale = 1.0f;

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
            card.Initialize(arr[i], gameManager.stageNum); // ���� �ϴܺ��� ���ʴ�� �����Ǵ� ī�忡 �迭�� ����� ���ڸ� �ο��Ѵ�.
        }
        cardCount = arr.Length;
    }

    private void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");

        if (time >= 30.0f) // ���� �й� ��
        {
            gameManager.LoadScene("FailScene");
        }
    }

    private void CheckMatching(Card[] cards)
    {
        if (cards[0].CardIndex == cards[1].CardIndex)
        {
            Debug.Log("Succes Card Matching.");

<<<<<<< Updated upstream
=======
            cards[0].SetMatched(); // ��ġ �Ϸ�
            // ������ ���� �ο�
            int randomEffect = Random.Range(1, 4);
            cards[0].EffectNumber = randomEffect;
            cards[1].EffectNumber = randomEffect;

>>>>>>> Stashed changes
            cards[0].SetMatched();
            cards[1].SetMatched();
            cardCount -= 2;

            if (cardCount == 0) // ���� �¸� ��
            {
                gameManager.LoadScene("SuccessScene");
            }
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
