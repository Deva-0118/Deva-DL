using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolWaterController : MonoBehaviour
{
    public float dropAmount = 0.01f; // �½���
    public float interval = 40f; // �½�ʱ�� (��)
    private Vector3 initialPosition; // ��¼��ʼλ��
    private Coroutine waterCoroutine;

    void Start()
    {
        initialPosition = transform.position; // ��¼��ʼλ��
        waterCoroutine = StartCoroutine(LowerWaterOverTime());
    }

    IEnumerator LowerWaterOverTime()
    {
        while (true)
        {
            Vector3 startPos = transform.position;
            Vector3 endPos = startPos - new Vector3(0, dropAmount, 0);
            float elapsedTime = 0;

            while (elapsedTime < interval)
            {
                transform.position = Vector3.Lerp(startPos, endPos, elapsedTime / interval);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = endPos;
        }
    }

    // **����ˮ��λ�õķ���**
    public void ResetPositionChange()
    {
        if (waterCoroutine != null)
        {
            StopCoroutine(waterCoroutine);
        }

        transform.position = initialPosition; // ��λ
        waterCoroutine = StartCoroutine(LowerWaterOverTime()); // ���¿�ʼ�½��߼�
    }
}
