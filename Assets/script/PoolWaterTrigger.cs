using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolWaterTrigger : MonoBehaviour
{
    public LeafController leafController; // ���� LeafController

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WaterCan"))
        {
            Debug.Log("WaterCan touched PoolWater, starting leaf color change.");
            leafController.StartColorChange(); // ��ʼҶ�ӱ�ɫ
        }
        if (other.CompareTag("Poop"))
        {
            Debug.Log("Poop touched PoolWater, resetting leaf color change.");
            leafController.ResetColorChange(); // Ҷ����ɫ�仯����
        }
    }
}

