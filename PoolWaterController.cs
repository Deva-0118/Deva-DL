using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class PoolWaterController : MonoBehaviour
{
    public float dropAmount = 0.01f; // 下降量
    public float interval = 40f; // 下降时间 (秒)

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
