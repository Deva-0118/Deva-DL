using UnityEngine;

public class PourDetector : MonoBehaviour
{
    public int pourThreshold = 45;  // 触发倒水的角度
    public Transform origin = null; // 倒水的起点
    public GameObject streamPrefab = null; // 水流的预制体

    private bool isPouring = false;
    private Stream currentStream = null;

    private void Update()
    {
        // 计算当前水壶的倾斜角度
        float angle = CalculatePourAngle();
        bool pourCheck = angle > pourThreshold; // 只有当角度大于 45° 时才倒水

        if (isPouring != pourCheck)  // 当状态变化时执行
        {
            isPouring = pourCheck;

            if (isPouring)
            {
                StartPour();
            }
            else
            {
                EndPour();
            }
        }
    }

    private void StartPour()
    {
        print("Start Pouring");

        if (currentStream == null)  // 避免重复创建水流
        {
            currentStream = CreateStream();
            if (currentStream != null)
            {
                currentStream.Begin();
            }
        }
    }

    private void EndPour()
    {
        print("End Pouring");

        if (currentStream != null)  // 避免空指针
        {
            Destroy(currentStream.gameObject);  // 销毁水流
            currentStream = null;
        }
    }

    private float CalculatePourAngle()
    {
        // 计算物体的 "up" 方向与世界 "up" 方向的夹角
        return Vector3.Angle(transform.up, Vector3.up);
    }

    private Stream CreateStream()
    {
        // 确保 origin 和 streamPrefab 被正确赋值
        if (origin == null || streamPrefab == null)
        {
            Debug.LogError("Origin or StreamPrefab is not assigned!");
            return null;
        }

        // 实例化水流预制体，并让它作为水壶的子物体
        GameObject streamObject = Instantiate(streamPrefab, origin.position, Quaternion.identity, transform);
        return streamObject.GetComponent<Stream>();
    }
}


