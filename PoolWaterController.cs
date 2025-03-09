using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class PoolWaterController : MonoBehaviour
{
    public float dropAmount = 0.01f; // �½���
    public float interval = 40f; // �½�ʱ�� (��)

    void Start()
    {
        StartCoroutine(LowerWaterOverTime());
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
}
