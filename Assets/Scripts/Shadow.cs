using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    private Vector2 mouseOffset = new Vector2(-0.03f, 0.03f);  // ���콺 ���� �� �̵��� ������ (X, Y)
    private Vector2 originalPosition;  // ���� ��ġ ����

    public GameObject shadow;  // �׸��� ������Ʈ
    private Vector3 shadowOffset = new Vector3(0.08f, -0.08f, 0.1f);  // �׸��� ������ (X, Y)
    private float shadowOpacity = 0.7f;  // �׸����� ����

    private SpriteRenderer shadowRenderer;
    private bool bActivate = true;

    public AudioClip clip;

    public void Deactivation()
    {
        // �׸��� ��Ȱ��ȭ
        bActivate = false;
    }
    public void Activation()
    {
        // �׸��� ��Ȱ��ȭ
        bActivate = true;
    }

    private void Start()
    {
        // �׸��� ������Ʈ�� SpriteRenderer�� ������
        shadowRenderer = shadow.GetComponent<SpriteRenderer>();

        // �ʱ⿡�� �׸��� ��Ȱ��ȭ
        shadow.SetActive(false);

        // ���� ��ġ ����
        originalPosition = transform.position;
    }


    private void OnMouseEnter()
    {
        if (!bActivate)
            return;

        // ���콺�� Sprite ���� �÷����� �׸��� ���̰� ����
        shadow.SetActive(true);

        // �׸����� ��ġ�� ���� (�⺻������ Sprite ��ġ + ������)
        shadow.transform.position = transform.position + shadowOffset;

        // �׸����� ������ ���������� �����ϰ�, ������ �ݿ�
        shadowRenderer.color = new Color(0, 0, 0, shadowOpacity);  // ������, ���� ����

        // ���콺�� ��ü ���� �÷����� ��ü�� ��¦ �̵���Ŵ
        transform.position = (Vector2)transform.position + mouseOffset;

        GameManager.Instance.SoundManager.SFXManager.OnPlaySound(clip, 2);

    }
    private void OnMouseExit()
    {
        if (!bActivate)
            return;

        // ���콺�� Sprite�� ����� �׸��� �����
        shadow.SetActive(false);

        // ���콺�� ��ü�� ����� ���� ��ġ�� ���ư�
        transform.position = originalPosition;
    }

    private void OnMouseDown()
    {
        if (!bActivate)
            return;

        shadow.SetActive(false);

        // ���콺�� ��ü�� ����� ���� ��ġ�� ���ư�
        transform.position = originalPosition;
    }
}
