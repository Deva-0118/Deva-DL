using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCan : MonoBehaviour
{
    public GameObject wheatPrefab;  // 小麦预制体
    private Transform[] wheatLands; // Wheat_Land 位置数组
    public GameObject waterMesh; // 指向水的 Mesh 物体
    private bool hasWater = false;  // 记录水壶是否装满

    void Start()
    {
        if (waterMesh != null)
        {
            waterMesh.SetActive(false); // 初始状态，水不可见
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PoolWater")) // 确保 poolWater 物体的 Tag 设为 "PoolWater"
        {
            hasWater = true;
            if (waterMesh != null)
            {
                waterMesh.SetActive(true); // 让水可见
            }
            Debug.Log("WaterCan is now filled!");
        }
        if (other.CompareTag("Farm") && hasWater) // 进入 Farm 自动浇水
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
        // 获取 Farm 里的所有 Wheat_Land
        wheatLands = farmTransform.GetComponentsInChildren<Transform>();

        int wheatCount = 0; // 计数，确保只生成 2 个小麦
        foreach (Transform land in wheatLands)
        {
            if (land.CompareTag("Wheat_Land") && wheatCount < 2) // 确保 `Wheat_Land` 物体正确命名，并且最多生成 2 个
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
        spawnPosition += new Vector3(Random.Range(-0.5f, 0.5f), 0, Random.Range(-0.5f, 0.5f)); // 让小麦位置有点随机偏移
        Instantiate(wheatPrefab, spawnPosition, Quaternion.identity);
        Debug.Log("Wheat generated at: " + spawnPosition);
    }

    public void PourWater()
    {
        hasWater = false; // 倾倒水后清空水壶
        if (waterMesh != null)
        {
            waterMesh.SetActive(false); // 让水不可见
        }
        Debug.Log("Water poured out!");
    }
}


