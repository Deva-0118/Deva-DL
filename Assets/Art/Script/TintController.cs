using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TintController : MonoBehaviour
{
    private Material material;
    public float duration = 40f; // ��ɫ�������ʱ�䣨�룩
    private float timer = 0f;
    private bool isChanging = true; // ��ɫ�Ƿ��ڱ仯��Ĭ������Ϊtrue

    public Color minColor = new Color(142f / 255f, 255f / 255f, 140f / 255f, 1f); // ��ʼ��ɫ
    public Color maxColor = new Color(255f / 255f, 255f / 255f, 255f / 255f, 0f); // Ŀ����ɫ��͸����Ϊ0��

    void Start()
    {
        material = GetComponent<Renderer>().material;
        material.SetColor("_MainColor", minColor); // ��ʼ����ɫ
        StartColorChange(); // ������ɫ�仯
    }

    void Update()
    {
        if (isChanging)
        {
            timer += Time.deltaTime;
            Debug.Log("Timer: " + timer);  // �������timer��ֵ

            float t = Mathf.Clamp01(timer / duration); // ��һ��ʱ�� 0~1

            // ������ɫ��������͸�����𽥴�1��Ϊ0
            Color dynamicColor = Color.Lerp(minColor, maxColor, t);
            material.SetColor("_MainColor", dynamicColor);

            // �޸� _Alpha ����������͸���ȷ�Χ�Ǵ� 1 �� 0
            float alpha = Mathf.Lerp(1f, 0f, t);
            material.SetFloat("_Alpha", alpha); // ����͸���ȱ��� _Alpha

            // ������� isChanging ״̬
            Debug.Log("isChanging: " + isChanging);

            // ��ʱ��ﵽ�趨ʱ����ֹͣ�仯
            if (timer >= duration)
            {
                Debug.Log("Timer reached duration. Disabling object.");
                gameObject.SetActive(false);
                isChanging = false; // ������� isChanging
                Debug.Log("isChanging updated to: " + isChanging); // ��ӡ���º�� isChanging
            }
        }
    }

    public void StartColorChange()
    {
        if (!isChanging) // ֻ�ڵ�һ�δ���ʱ������ʱ
        {
            timer = 0f;
            isChanging = true;
        }
    }

    public void ResetColorChange()
    {
        timer = 0f;
        isChanging = true;
        material.SetColor("_MainColor", minColor); // ����Ϊ��ʼ��ɫ
    }
}
