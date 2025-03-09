using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    private Vector3 initialPosition; // 存储 Apple 初始位置
    private Quaternion initialRotation; // 存储 Apple 初始旋转
    public GameObject applePrefab; // Apple 预制体

    private void Start()
    {
        initialPosition = transform.position; // 记录初始位置
        initialRotation = transform.rotation; // 记录初始旋转
    }

    public void DestroyApple()
    {
        Destroy(gameObject); // 彻底销毁 Apple
    }

    public void RespawnApple()
    {
        if (applePrefab != null)
        {
            Instantiate(applePrefab, initialPosition, initialRotation);
        }
        else
        {
            Debug.LogError("Apple prefab is not assigned!");
        }
    }
}

