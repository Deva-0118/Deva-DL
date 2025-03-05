using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TintController : MonoBehaviour
{
    private Material material;
    public float duration = 40f; // 颜色渐变持续时间（秒）
    private float timer = 0f;
    private bool isChanging = true; // 颜色是否在变化，默认设置为true

    public Color minColor = new Color(142f / 255f, 255f / 255f, 140f / 255f, 1f); // 初始颜色
    public Color maxColor = new Color(255f / 255f, 255f / 255f, 255f / 255f, 0f); // 目标颜色（透明度为0）

    void Start()
    {
        material = GetComponent<Renderer>().material;
        material.SetColor("_MainColor", minColor); // 初始化颜色
        StartColorChange(); // 启动颜色变化
    }

    void Update()
    {
        if (isChanging)
        {
            timer += Time.deltaTime;
            Debug.Log("Timer: " + timer);  // 调试输出timer的值

            float t = Mathf.Clamp01(timer / duration); // 归一化时间 0~1

            // 渐变颜色，并且让透明度逐渐从1变为0
            Color dynamicColor = Color.Lerp(minColor, maxColor, t);
            material.SetColor("_MainColor", dynamicColor);

            // 修改 _Alpha 变量，假设透明度范围是从 1 到 0
            float alpha = Mathf.Lerp(1f, 0f, t);
            material.SetFloat("_Alpha", alpha); // 设置透明度变量 _Alpha

            // 调试输出 isChanging 状态
            Debug.Log("isChanging: " + isChanging);

            // 当时间达到设定时长，停止变化
            if (timer >= duration)
            {
                Debug.Log("Timer reached duration. Disabling object.");
                gameObject.SetActive(false);
                isChanging = false; // 这里更新 isChanging
                Debug.Log("isChanging updated to: " + isChanging); // 打印更新后的 isChanging
            }
        }
    }

    public void StartColorChange()
    {
        if (!isChanging) // 只在第一次触发时启动计时
        {
            timer = 0f;
            isChanging = true;
        }
    }

    public void ResetColorChange()
    {
        timer = 0f;
        isChanging = true;
        material.SetColor("_MainColor", minColor); // 重置为初始颜色
    }
}
