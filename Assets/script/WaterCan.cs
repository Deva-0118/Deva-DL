using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCan : MonoBehaviour
{
    public GameObject wheatPrefab;  // С��Ԥ����
    public GameObject waterMesh; // ָ��ˮ�� Mesh ����
    private bool hasWater = false;  // ��¼ˮ���Ƿ�װ��

    void Start()
    {
        if (waterMesh != null)
        {
            waterMesh.SetActive(false); // ��ʼ״̬��ˮ���ɼ�
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PoolWater")) // ȷ�� poolWater ����� Tag ��Ϊ "PoolWater"
        {
            hasWater = true;
            if (waterMesh != null)
            {
                waterMesh.SetActive(true); // ��ˮ�ɼ�
            }
            Debug.Log("WaterCan is now filled!");
        }
        if (other.CompareTag("Farm") && hasWater) // ���� Farm �Զ���ˮ
        {
            FindWheatLands(other.transform);
            PourWater();
        }
    }

    public bool IsFilled()
    {
        return hasWater;
    }

    void FindWheatLands(Transform farmTransform)
    {
        Transform[] wheatLands = farmTransform.GetComponentsInChildren<Transform>();

        int wheatCount = 0; // ������ȷ��������� 2 ��С��
        foreach (Transform land in wheatLands)
        {
            if (land.CompareTag("Wheat_Land") && wheatCount < 2) // ȷ�� `Wheat_Land` ������ȷ����������������� 2 ��
            {
                // **��� Wheat_Land �Ƿ�����С��**
                if (!HasWheat(land))
                {
                    GenerateWheat(land);
                    wheatCount++;
                }
            }
        }

        if (wheatCount < 2)
        {
            Debug.LogWarning("Not enough empty Wheat_Lands found in Farm!");
        }
    }

    /// **��� Wheat_Land �Ƿ�����С��**
    bool HasWheat(Transform wheatLand)
    {
        foreach (Transform child in wheatLand)
        {
            if (child.CompareTag("Wheat")) // ȷ��С��� Tag ����Ϊ "Wheat"
            {
                return true; // �Ѿ���С�󣬲�����
            }
        }
        return false; // û��С�󣬿�������
    }

    void GenerateWheat(Transform wheatLand)
    {
        Vector3 spawnPosition = wheatLand.position; // ����λ��
        spawnPosition.y += 0.1f; // ȷ��С�󲻻Ῠ������

        Quaternion wheatRotation = Quaternion.Euler(-90, 0, 0); // ��ת����
        GameObject wheatInstance = Instantiate(wheatPrefab, spawnPosition, wheatRotation);

        // **�� Wheat ��Ϊ Wheat_Land �������壬�������**
        wheatInstance.transform.SetParent(wheatLand);

        Debug.Log("Wheat generated at: " + spawnPosition);
    }

    public void PourWater()
    {
        hasWater = false; // �㵹ˮ�����ˮ��
        if (waterMesh != null)
        {
            waterMesh.SetActive(false); // ��ˮ���ɼ�
        }
        Debug.Log("Water poured out!");
    }
}





