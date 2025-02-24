using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCanTilt : MonoBehaviour
{
    public GameObject wheatPrefab; // 小麦预制体
    private Transform wheatLand; // 小麦生成区域
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
            waterCan.PourWater(); // 清空水壶
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

            // **自动找到 Farm 内的 wheat_land**
            Transform farmTransform = other.transform;
            wheatLand = farmTransform.Find("Wheat_Land"); // 确保 Farm 下有 Wheat_Land 物体

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
            wheatLand = null; // 退出农场后清空 wheatLand
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
            // 在 wheatLand 附近生成小麦
            Vector3 spawnPos = wheatLand.position + new Vector3(Random.Range(-0.5f, 0.5f), 0, Random.Range(-0.5f, 0.5f));
            Instantiate(wheatPrefab, spawnPos, Quaternion.identity);
        }
    }
}


