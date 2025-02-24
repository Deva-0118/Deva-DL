using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCan : MonoBehaviour
{
    public GameObject wheatPrefab;  // С��Ԥ����
    private Transform[] wheatLands; // Wheat_Land λ������
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
        // ��ȡ Farm ������� Wheat_Land
        wheatLands = farmTransform.GetComponentsInChildren<Transform>();

        int wheatCount = 0; // ������ȷ��ֻ���� 2 ��С��
        foreach (Transform land in wheatLands)
        {
            if (land.CompareTag("Wheat_Land") && wheatCount < 2) // ȷ�� `Wheat_Land` ������ȷ����������������� 2 ��
            {
                GenerateWheat(land.position);
                wheatCount++;
            }
        }

        if (wheatCount < 2)
        {
            Debug.LogWarning("Not enough Wheat_Land found in Farm!");
        }
    }

    void GenerateWheat(Vector3 spawnPosition)
    {
        spawnPosition += new Vector3(Random.Range(-0.5f, 0.5f), 0, Random.Range(-0.5f, 0.5f)); // ��С��λ���е����ƫ��
        Instantiate(wheatPrefab, spawnPosition, Quaternion.identity);
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


