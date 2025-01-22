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

        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 }; // 배열 선언
        arr = arr.OrderBy(x => Random.Range(0f, 7f)).ToArray(); // 선언한 배열을 랜덤하게 섞어 정렬한다.

        for (int i = 0; i < boardSize * boardSize; i++)
        {
            float x = (i % boardSize) * margin - 1.6f;
            float y = (i / boardSize) * margin - 1.7f;

            Card card = Instantiate(cardPrefab, new Vector3(x, y, 0), Quaternion.identity);
            card.Initialize(arr[i], gameManager.stageNum); // 좌측 하단부터 차례대로 생성되는 카드에 배열에 저장된 숫자를 부여한다.
        }
        cardCount = arr.Length;
    }

    private void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");

        if (time >= 30.0f) // 게임 패배 시
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
            cards[0].SetMatched(); // 매치 완료
            // 랜덤한 숫자 부여
            int randomEffect = Random.Range(1, 4);
            cards[0].EffectNumber = randomEffect;
            cards[1].EffectNumber = randomEffect;

>>>>>>> Stashed changes
            cards[0].SetMatched();
            cards[1].SetMatched();
            cardCount -= 2;

            if (cardCount == 0) // 게임 승리 시
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
