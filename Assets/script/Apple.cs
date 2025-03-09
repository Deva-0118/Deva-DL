using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    private Vector3 initialPosition; // �洢 Apple ��ʼλ��
    private Quaternion initialRotation; // �洢 Apple ��ʼ��ת
    public GameObject applePrefab; // Apple Ԥ����

    private void Start()
    {
        initialPosition = transform.position; // ��¼��ʼλ��
        initialRotation = transform.rotation; // ��¼��ʼ��ת
    }

    public void DestroyApple()
    {
        Destroy(gameObject); // �������� Apple
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

