using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafController : MonoBehaviour
{
    public Material leafMaterial; // 叶子材质
    private Color startColor = new Color(142f / 255f, 255f / 255f, 140f / 255f, 1f); // 初始颜色（RGBA）
    private Color endColor = new Color(255f / 255f, 255f / 255f, 255f / 255f, 0f);   // 目标颜色（RGBA）

    private float duration = 40f; // 颜色变化总时长（秒）
    private float timer = 0f; // 计时器
    private bool isChanging = false; // 是否开始颜色渐变

    void Start()
    {
        if (leafMaterial == null)
        {
            Debug.LogError("Leaf material is not assigned!");
            return;
        }

        // 初始化 Leaf 材质颜色
        leafMaterial.color = startColor;
    }

    void Update()
    {
        if (isChanging)
        {
            timer += Time.deltaTime;
            float t = Mathf.Clamp01(timer / duration); // 归一化时间，确保 0 ~ 1
            leafMaterial.color = Color.Lerp(startColor, endColor, t); // 颜色平滑过渡
        }
    }

    public void StartColorChange()
    {
        timer = 0f; // 重新计时
        isChanging = true;
    }

    public void ResetColorChange()
    {
        timer = 0f; // 重新计时
        isChanging = true;
        leafMaterial.color = startColor; // 重置 Leaf 颜色
    }
}


