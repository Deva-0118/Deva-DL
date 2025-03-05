using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafTintController : MonoBehaviour
{
    public Material leafMaterial; // 叶子材质
    public float duration = 40f; // 颜色变化总时长（秒）
    private float timer = 0f; // 计时器
    private bool isChanging = false; // 是否开始颜色渐变
    public Apple apple;

    private Color minColor = new Color(142f / 255f, 255f / 255f, 140f / 255f, 1f); // 初始颜色
    private Color maxColor = new Color(255f / 255f, 255f / 255f, 255f / 255f, 0f); // 目标颜色（透明）

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
            float t = Mathf.Clamp01(timer / duration); // 归一化时间 0 ~ 1
            Color dynamicColor = Color.Lerp(minColor, maxColor, t);
            leafMaterial.SetColor("_MainColor", dynamicColor);
            float alpha = Mathf.Lerp(1f, 0f, t);
            leafMaterial.SetFloat("_Alpha", alpha); // 设置透明度变量 _Alpha

            if(duration <= timer)
            {
                isChanging = false;
                apple.AppleDisAppear();
            }
        }
    }

    public void StartColorChange()
    {
        if (!isChanging) // 只在首次触发时启动计时
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

