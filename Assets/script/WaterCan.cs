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
            PoolWater poolWater = other.GetComponent<PoolWater>(); // ��ȡ PoolWater �ű�
            hasWater = true;
            if (waterMesh != null)
            {
                poolWater.OnWaterCanTouch(); // ���� PoolWater �еķ���
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

        if (wheatCount == 0)
        {
            Debug.LogWarning("All Wheat_Lands are occupied! No new wheat generated.");
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
        // **����С�����ɵ��ģ������� X ����ת**
        Quaternion wheatRotation = Quaternion.Euler(-90, 0, 0); // ��������� X ��

        GameObject wheatInstance = Instantiate(wheatPrefab, wheatLand.position, wheatRotation);

        // **����С��ײ��������**
        Renderer wheatRenderer = wheatInstance.GetComponent<Renderer>();
        if (wheatRenderer != null)
        {
            float offset = wheatInstance.transform.position.y - wheatRenderer.bounds.min.y;
            wheatInstance.transform.position -= new Vector3(0, offset, 0);
        }

        // **��Ϊ Wheat_Land ������**
        wheatInstance.transform.SetParent(wheatLand);

        Debug.Log("Wheat generated at: " + wheatInstance.transform.position);
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





