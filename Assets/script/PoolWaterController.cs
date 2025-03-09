using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolWaterController : MonoBehaviour
{
    public float dropAmount = 0.01f; // 下降量
    public float interval = 40f; // 下降时间 (秒)
    private Vector3 initialPosition; // 记录初始位置
    private Coroutine waterCoroutine;

    void Start()
    {
        initialPosition = transform.position; // 记录初始位置
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

    // **重置水池位置的方法**
    public void ResetPositionChange()
    {
        if (waterCoroutine != null)
        {
            StopCoroutine(waterCoroutine);
        }

        transform.position = initialPosition; // 归位
        waterCoroutine = StartCoroutine(LowerWaterOverTime()); // 重新开始下降逻辑
    }
}
