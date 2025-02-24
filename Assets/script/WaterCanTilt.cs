using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCanTilt : MonoBehaviour
{
    public GameObject wheatPrefab; // С��Ԥ����
    private Transform wheatLand; // С����������
    private WaterCan waterCan;
    private bool isInFarm = false;

    void Start()
    {
        waterCan = GetComponent<WaterCan>();
    }

    void Update()
    {
        if (isInFarm && waterCan.IsFilled() && IsTilted())
        {
            GenerateWheat();
            waterCan.PourWater(); // ���ˮ��
        }
    }

    bool IsTilted()
    {
        float tiltThreshold = 45f;
        float xTilt = Mathf.Abs(transform.eulerAngles.x);
        float zTilt = Mathf.Abs(transform.eulerAngles.z);

        return xTilt > tiltThreshold || zTilt > tiltThreshold;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Farm"))
        {
            isInFarm = true;

            // **�Զ��ҵ� Farm �ڵ� wheat_land**
            Transform farmTransform = other.transform;
            wheatLand = farmTransform.Find("Wheat_Land"); // ȷ�� Farm ���� Wheat_Land ����

            if (wheatLand == null)
            {
                Debug.LogError("Wheat_Land not found under Farm!");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Farm"))
        {
            isInFarm = false;
            wheatLand = null; // �˳�ũ������� wheatLand
        }
    }

    void GenerateWheat()
    {
        if (wheatLand == null)
        {
            Debug.LogError("Cannot generate wheat: Wheat_Land is missing!");
            return;
        }

        Debug.Log("Generating wheat...");

        for (int i = 0; i < 2; i++)
        {
            // �� wheatLand ��������С��
            Vector3 spawnPos = wheatLand.position + new Vector3(Random.Range(-0.5f, 0.5f), 0, Random.Range(-0.5f, 0.5f));
            Instantiate(wheatPrefab, spawnPos, Quaternion.identity);
        }
    }
}


