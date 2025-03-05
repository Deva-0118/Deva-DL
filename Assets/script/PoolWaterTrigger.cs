using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolWaterTrigger : MonoBehaviour
{
    public LeafController leafController; // 关联 LeafController

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WaterCan"))
        {
            Debug.Log("WaterCan touched PoolWater, starting leaf color change.");
            leafController.StartColorChange(); // 开始叶子变色
        }
        if (other.CompareTag("Poop"))
        {
            Debug.Log("Poop touched PoolWater, resetting leaf color change.");
            leafController.ResetColorChange(); // 叶子颜色变化重置
        }
    }
}

