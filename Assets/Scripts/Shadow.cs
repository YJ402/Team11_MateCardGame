using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    private Vector2 mouseOffset = new Vector2(-0.03f, 0.03f);  // 마우스 오버 시 이동할 오프셋 (X, Y)
    private Vector2 originalPosition;  // 원래 위치 저장

    public GameObject shadow;  // 그림자 오브젝트
    private Vector3 shadowOffset = new Vector3(0.08f, -0.08f, 0.1f);  // 그림자 오프셋 (X, Y)
    private float shadowOpacity = 0.7f;  // 그림자의 투명도

    private SpriteRenderer shadowRenderer;
    private bool bActivate = true;

    public AudioClip clip;

    public void Deactivation()
    {
        // 그림자 비활성화
        bActivate = false;
    }
    public void Activation()
    {
        // 그림자 비활성화
        bActivate = true;
    }

    private void Start()
    {
        // 그림자 오브젝트의 SpriteRenderer를 가져옴
        shadowRenderer = shadow.GetComponent<SpriteRenderer>();

        // 초기에는 그림자 비활성화
        shadow.SetActive(false);

        // 원래 위치 저장
        originalPosition = transform.position;
    }


    private void OnMouseEnter()
    {
        if (!bActivate)
            return;

        // 마우스가 Sprite 위에 올려지면 그림자 보이게 설정
        shadow.SetActive(true);

        // 그림자의 위치를 설정 (기본적으로 Sprite 위치 + 오프셋)
        shadow.transform.position = transform.position + shadowOffset;

        // 그림자의 색상을 검은색으로 설정하고, 투명도를 반영
        shadowRenderer.color = new Color(0, 0, 0, shadowOpacity);  // 검은색, 투명도 설정

        // 마우스가 객체 위에 올려지면 객체를 살짝 이동시킴
        transform.position = (Vector2)transform.position + mouseOffset;

        GameManager.Instance.SoundManager.SFXManager.OnPlaySound(clip, 2);

    }
    private void OnMouseExit()
    {
        if (!bActivate)
            return;

        // 마우스가 Sprite를 벗어나면 그림자 숨기기
        shadow.SetActive(false);

        // 마우스가 객체를 벗어나면 원래 위치로 돌아감
        transform.position = originalPosition;
    }

    private void OnMouseDown()
    {
        if (!bActivate)
            return;

        shadow.SetActive(false);

        // 마우스가 객체를 벗어나면 원래 위치로 돌아감
        transform.position = originalPosition;
    }
}
