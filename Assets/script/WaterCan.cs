using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCan : MonoBehaviour
{
    public GameObject wheatPrefab;  // 小麦预制体
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
            PoolWater poolWater = other.GetComponent<PoolWater>(); // 获取 PoolWater 脚本
            hasWater = true;
            if (waterMesh != null)
            {
                poolWater.OnWaterCanTouch(); // 调用 PoolWater 中的方法
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
        Transform[] wheatLands = farmTransform.GetComponentsInChildren<Transform>();

        int wheatCount = 0; // 计数，确保最多生成 2 个小麦
        foreach (Transform land in wheatLands)
        {
            if (land.CompareTag("Wheat_Land") && wheatCount < 2) // 确保 `Wheat_Land` 物体正确命名，并且最多生成 2 个
            {
                // **检查 Wheat_Land 是否已有小麦**
                if (!HasWheat(land))
                {
                    GenerateWheat(land);
                    wheatCount++;
                }
            }
        }

        if (wheatCount == 0)
        {
            Debug.LogWarning("All Wheat_Lands are occupied! No new wheat generated.");
        }
    }

    /// **检查 Wheat_Land 是否已有小麦**
    bool HasWheat(Transform wheatLand)
    {
        foreach (Transform child in wheatLand)
        {
            if (child.CompareTag("Wheat")) // 确保小麦的 Tag 设置为 "Wheat"
            {
                return true; // 已经有小麦，不生成
            }
        }
        return false; // 没有小麦，可以生成
    }

    void GenerateWheat(Transform wheatLand)
    {
        // **假设小麦是躺倒的，调整其 X 轴旋转**
        Quaternion wheatRotation = Quaternion.Euler(-90, 0, 0); // 视情况调整 X 轴

        GameObject wheatInstance = Instantiate(wheatPrefab, wheatLand.position, wheatRotation);

        // **修正小麦底部对齐地面**
        Renderer wheatRenderer = wheatInstance.GetComponent<Renderer>();
        if (wheatRenderer != null)
        {
            float offset = wheatInstance.transform.position.y - wheatRenderer.bounds.min.y;
            wheatInstance.transform.position -= new Vector3(0, offset, 0);
        }

        // **设为 Wheat_Land 子物体**
        wheatInstance.transform.SetParent(wheatLand);

        Debug.Log("Wheat generated at: " + wheatInstance.transform.position);
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





