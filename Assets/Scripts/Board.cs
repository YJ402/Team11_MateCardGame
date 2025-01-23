using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Board : MonoBehaviour
{
    public int boardSize = 4;

    public Card cardPrefab;

    public float margin = 1.1f;
    public TextMeshProUGUI timeTxt;

    public int cardCount = 0;
    float time = 0.0f;

    public AudioClip matchingClip;

    public List<AudioClip> bgmClips = new List<AudioClip>();

    private GameManager gameManager;
    private CardControl cardControl;

    private void Start()
    {
        Time.timeScale = 1.0f;

        gameManager = GameManager.Instance;
        gameManager.SoundManager.BGMManager.OnPlaySound(bgmClips[gameManager.stageNum - 1], 0.1f);
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

            Card card = Instantiate(cardPrefab, new Vector3(x, 1.1f + y, 0), Quaternion.identity);
            card.Initialize(Random.Range(0, 20), arr[i], gameManager.stageNum); // 좌측 하단부터 차례대로 생성되는 카드에 배열에 저장된 숫자를 부여한다.
        }
        cardCount = arr.Length;
    }

    private void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("00.00").Replace('.', ' ');

        if (time >= 130.0f) // 게임 패배 시
        {
            gameManager.LoadScene("FailScene");
        }
    }

    private void CheckMatching(Card[] cards)
    {
        if (cards[0].CardIndex == cards[1].CardIndex)
        {
            Debug.Log("Succes Card Matching.");

            // 랜덤한 숫자 부여
            int randomEffect = Random.Range(1, 4);

            cards[0].SetMatched(randomEffect);
            cards[1].SetMatched(randomEffect);

            cardCount -= 2;

            gameManager.SoundManager.SFXManager.OnPlaySound(matchingClip);

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