
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
                Debug.Log("Card::SetMatched - �߸��� �������� ���Ե�");
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
        // ī�带 1.0�� ���� Y������ 180�� ȸ��
        yield return RotateAxisYOverTime(180f, 1f);
    }
    private IEnumerator Effect2()
    {
        // 1. ī�带 0.8�� ���� Y������ 1980�� ȸ��
        yield return StartCoroutine(RotateAxisYOverTime(1980f, 0.8f));

        // 2. ī�带 0.2�� ���� 1.8�� Ȯ�� �� �ٽ� ����ϴ� ���� 1�� �ݺ�
        Vector3 targetScale = transform.localScale * 1.8f;
        yield return StartCoroutine(ScalingUpDownNCounts(targetScale, 0.2f, 1));
    }
    private IEnumerator Effect3()
    {
        // 1. ī�带 0.6�� ���� Y������ 540�� ȸ��
        yield return StartCoroutine(RotateAxisYOverTime(540f, 0.3f));

        // 2. ī�带 0.4�� ���� 1.8�� Ȯ�� �� �ٽ� ����ϴ� ���� 2�� �ݺ�
        Vector3 targetScale = transform.localScale * 1.8f;
        yield return StartCoroutine(ScalingUpDownNCounts(targetScale, 0.4f, 2));
    }


    // ī�带 y������ targetAngle ���� ��ŭ duration �ð� ���� ������ �Լ�
    private IEnumerator RotateAxisYOverTime(float targetAngle, float duration)
    {
        // ������� ���ư� ����
        float totalRotation = 0f;

        // ȣ��� ���ư����ϴ� ����
        float rotationPerFrame = targetAngle / duration;

        // ���� ���ư� ������ Ÿ�� �������� �۴ٸ�
        while (totalRotation < targetAngle)
        {
            // timer�� ����ؼ� ȸ�� �õ�
            float rotationStep = rotationPerFrame * Time.deltaTime;
            transform.Rotate(0, rotationStep, 0);
            totalRotation += rotationStep;
            yield return null;
        }

        // ���ʹϾ� ������� ���� ȸ������ ���� ������ ���� (���� ����)
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + (targetAngle - totalRotation), transform.eulerAngles.z);
    }


    // ī���� ũ�⸦ duration �ð����� cardScale���� Ű���ٰ� �����·� �ǵ����� ���� count ��ŭ �ݺ��ϴ� �Լ�
    private IEnumerator ScalingUpDownNCounts(Vector3 targetScale, float duration, int count)
    {
        Vector3 originalScale = transform.localScale;
        for (int i = 0; i < count; i++)
        {
            // Ȯ��
            yield return StartCoroutine(ScalingOverTime(targetScale, duration / count));

            // ���
            yield return StartCoroutine(ScalingOverTime(originalScale, duration / count));
        }
    }

    // �־��� �ð����� ũ�⸦ �����ϴ� �Լ�
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
