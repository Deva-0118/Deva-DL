using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafTintController : MonoBehaviour
{
    public Material leafMaterial; // Ҷ�Ӳ���
    public float duration = 40f; // ��ɫ�仯��ʱ�����룩
    private float timer = 0f; // ��ʱ��
    private bool isChanging = false; // �Ƿ�ʼ��ɫ����
    public Apple apple;

    private Color minColor = new Color(142f / 255f, 255f / 255f, 140f / 255f, 1f); // ��ʼ��ɫ
    private Color maxColor = new Color(255f / 255f, 255f / 255f, 255f / 255f, 0f); // Ŀ����ɫ��͸����

    void Start()
    {
        if (leafMaterial == null)
        {
            Debug.LogError("Leaf material is not assigned!");
            return;
        }
        leafMaterial.SetColor("_MainColor", minColor);
        StartColorChange();
    }

    void Update()
    {
        if (isChanging)
        {
            timer += Time.deltaTime;
            float t = Mathf.Clamp01(timer / duration); // ��һ��ʱ�� 0 ~ 1
            Color dynamicColor = Color.Lerp(minColor, maxColor, t);
            leafMaterial.SetColor("_MainColor", dynamicColor);
            float alpha = Mathf.Lerp(1f, 0f, t);
            leafMaterial.SetFloat("_Alpha", alpha); // ����͸���ȱ��� _Alpha

            if(duration <= timer)
            {
                isChanging = false;
                apple.AppleDisAppear();
            }
        }
    }

    public void StartColorChange()
    {
        if (!isChanging) // ֻ���״δ���ʱ������ʱ
        {
            timer = 0f;
            isChanging = true;
        }
    }

    public void ResetColorChange()
    {
        timer = 0f;
        isChanging = true;
        leafMaterial.SetColor("_MainColor", minColor);
        apple.AppleAppear();
    }
}

