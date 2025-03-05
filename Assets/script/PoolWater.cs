using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolWater : MonoBehaviour
{
    private Renderer poolWaterRenderer;
    private int touchCount = 0; // 触碰   计数器
    public Material poolMaterial;

    // 颜色变化数组
    private Color[] colors = new Color[]
    {
        new Color(238f / 255f, 220f / 255f, 209f / 255f), // 第一次颜色
        new Color(225f / 255f, 187f / 255f, 162f / 255f), // 第二次颜色
        new Color(218f / 255f, 151f / 255f, 108f / 255f)  // 第三次颜色
    };

    // 预定义的 Y 轴水位高度（相对于父级）
    private float[] Y_Heights = new float[] { -0.007f, 0f, -0.0135f };

    void Start()
    {
        // 获取 PoolWater 的 Renderer 组件，以便修改颜色
        poolWaterRenderer = GetComponent<Renderer>();

        // 初始化水的初始高度（使用 localPosition 以避免全局坐标问题）
        transform.localPosition = new Vector3(transform.localPosition.x, 0.0134f, transform.localPosition.z);
    }

    // 这个方法可以通过 WaterCan 脚本调用，当 WaterCan 和 PoolWater 接触时触发
    public void OnWaterCanTouch()
    {
        if (touchCount < 3)
        {
            // 让 PoolWater 下降到下一个阶段
            transform.localPosition = new Vector3(transform.localPosition.x, Y_Heights[touchCount], transform.localPosition.z);

            // 更新颜色
            poolMaterial.color = colors[touchCount];

            // 增加触碰计数
            touchCount++;
        }
    }

    // 这个方法可以被外部代码调用来重置水池状态
    public void ResetWater()
    {
        touchCount = 0;
        transform.localPosition = new Vector3(transform.localPosition.x, 0.0134f, transform.localPosition.z);
        poolWaterRenderer.material.color = colors[0];
    }
}
