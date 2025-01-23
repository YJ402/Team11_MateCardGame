
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public SpriteRenderer backImage;
    public SpriteRenderer frontImage;
    public SpriteRenderer frameImage; // BackFrame
    public int CardIndex { get; private set; }
    public int Stage { get; private set; }
    public bool IsMatched { get; private set; }

    private float remainTime { get; set; }

    public bool bDestroyStart { get; set; } = false;

    public Shadow shadow { get; private set; }

    public void Initialize(int cardbackImage, int cardIndex, int stageNum)
    {
        Stage = stageNum;
        CardIndex = cardIndex;
        backImage.sprite = Resources.Load<Sprite>("CardBackImage/Back_" + cardbackImage);
        frontImage.sprite = Resources.Load<Sprite>($"Stage{Stage}/img{CardIndex}");
        frameImage.sprite = Resources.Load<Sprite>("Frame"); ; // BackFrame

        shadow = GetComponent<Shadow>();
    }


    public void SetMatched(int EffectNumber)
    {
        IsMatched = true;
        shadow.Deactivation();

        Debug.Log(EffectNumber);

        transform.rotation = Quaternion.identity;
        switch (EffectNumber)
        {
            case 1:
                StartCoroutine(Effect1());
                break;
            case 2:
                StartCoroutine(Effect2());
                break;
            case 3:
                StartCoroutine(Effect3());
                break;
            default:
                Debug.Log("Card::SetMatched - 잘못된 랜덤값이 삽입됨");
                break;
        }

        StartCoroutine(Shining(2f));
    }

    private IEnumerator Shining(float duration)
    {
        float shineLocation = 0;

        while (true)
        {
            shineLocation += 1.0f / duration * Time.deltaTime;
            shineLocation %= 1.0f;

            frontImage.material.SetFloat("_ShineLocation", shineLocation);

            yield return null;
        }
    }


    public void WaitForSecondToFlip(float time)
    {
        Invoke("Flip", time);
    }

    public void Flip()
    {
        if (!IsMatched)
        {
            transform.Rotate(0, 180, 0);
        }
    }
    private IEnumerator Effect1()
    {
        // 카드를 1.0초 동안 Y축으로 180도 회전
        yield return RotateAxisYOverTime(180f, 1f);
    }
    private IEnumerator Effect2()
    {
        // 1. 카드를 0.8초 동안 Y축으로 1980도 회전
        yield return StartCoroutine(RotateAxisYOverTime(1980f, 0.8f));

        // 2. 카드를 0.2초 동안 1.8배 확대 후 다시 축소하는 것을 1번 반복
        Vector3 targetScale = transform.localScale * 1.8f;
        yield return StartCoroutine(ScalingUpDownNCounts(targetScale, 0.2f, 1));
    }
    private IEnumerator Effect3()
    {
        // 1. 카드를 0.6초 동안 Y축으로 540도 회전
        yield return StartCoroutine(RotateAxisYOverTime(540f, 0.3f));

        // 2. 카드를 0.4초 동안 1.8배 확대 후 다시 축소하는 것을 2번 반복
        Vector3 targetScale = transform.localScale * 1.8f;
        yield return StartCoroutine(ScalingUpDownNCounts(targetScale, 0.4f, 2));
    }


    // 카드를 y축으로 targetAngle 각도 만큼 duration 시간 동안 돌리는 함수
    private IEnumerator RotateAxisYOverTime(float targetAngle, float duration)
    {
        // 기존대비 돌아간 각도
        float totalRotation = 0f;

        // 호출당 돌아가야하는 각도
        float rotationPerFrame = targetAngle / duration;

        // 현재 돌아간 각도가 타겟 각도보다 작다면
        while (totalRotation < targetAngle)
        {
            // timer를 사용해서 회전 시도
            float rotationStep = rotationPerFrame * Time.deltaTime;
            transform.Rotate(0, rotationStep, 0);
            totalRotation += rotationStep;
            yield return null;
        }

        // 쿼터니언 방식으로 최종 회전값에 대한 오차를 수정 (오차 방지)
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + (targetAngle - totalRotation), transform.eulerAngles.z);
    }


    // 카드의 크기를 duration 시간동안 cardScale까지 키웠다가 원상태로 되돌리는 것을 count 만큼 반복하는 함수
    private IEnumerator ScalingUpDownNCounts(Vector3 targetScale, float duration, int count)
    {
        Vector3 originalScale = transform.localScale;
        for (int i = 0; i < count; i++)
        {
            // 확대
            yield return StartCoroutine(ScalingOverTime(targetScale, duration / count));

            // 축소
            yield return StartCoroutine(ScalingOverTime(originalScale, duration / count));
        }
    }

    // 주어진 시간동안 크기를 조정하는 함수
    private IEnumerator ScalingOverTime(Vector3 targetScale, float duration)
    {
        Vector3 startScale = transform.localScale;
        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            transform.localScale = Vector3.Lerp(startScale, targetScale, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetScale;
    }
}
