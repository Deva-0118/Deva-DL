using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafController : MonoBehaviour
{
    public Material leafMaterial; // Ҷ�Ӳ���
    private Color startColor = new Color(142f / 255f, 255f / 255f, 140f / 255f, 1f); // ��ʼ��ɫ��RGBA��
    private Color endColor = new Color(255f / 255f, 255f / 255f, 255f / 255f, 0f);   // Ŀ����ɫ��RGBA��

    private float duration = 40f; // ��ɫ�仯��ʱ�����룩
    private float timer = 0f; // ��ʱ��
    private bool isChanging = false; // �Ƿ�ʼ��ɫ����

    void Start()
    {
        if (leafMaterial == null)
        {
            Debug.LogError("Leaf material is not assigned!");
            return;
        }

        // ��ʼ�� Leaf ������ɫ
        leafMaterial.color = startColor;
    }

    void Update()
    {
        if (isChanging)
        {
            timer += Time.deltaTime;
            float t = Mathf.Clamp01(timer / duration); // ��һ��ʱ�䣬ȷ�� 0 ~ 1
            leafMaterial.color = Color.Lerp(startColor, endColor, t); // ��ɫƽ������
        }
    }

    public void StartColorChange()
    {
        timer = 0f; // ���¼�ʱ
        isChanging = true;
    }

    public void ResetColorChange()
    {
        timer = 0f; // ���¼�ʱ
        isChanging = true;
        leafMaterial.color = startColor; // ���� Leaf ��ɫ
    }
}


