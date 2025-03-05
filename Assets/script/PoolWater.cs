using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolWater : MonoBehaviour
{
    private Renderer poolWaterRenderer;
    private int touchCount = 0; // ����   ������
    public Material poolMaterial;

    // ��ɫ�仯����
    private Color[] colors = new Color[]
    {
        new Color(238f / 255f, 220f / 255f, 209f / 255f), // ��һ����ɫ
        new Color(225f / 255f, 187f / 255f, 162f / 255f), // �ڶ�����ɫ
        new Color(218f / 255f, 151f / 255f, 108f / 255f)  // ��������ɫ
    };

    // Ԥ����� Y ��ˮλ�߶ȣ�����ڸ�����
    private float[] Y_Heights = new float[] { -0.007f, 0f, -0.0135f };

    void Start()
    {
        // ��ȡ PoolWater �� Renderer ������Ա��޸���ɫ
        poolWaterRenderer = GetComponent<Renderer>();

        // ��ʼ��ˮ�ĳ�ʼ�߶ȣ�ʹ�� localPosition �Ա���ȫ���������⣩
        transform.localPosition = new Vector3(transform.localPosition.x, 0.0134f, transform.localPosition.z);
    }

    // �����������ͨ�� WaterCan �ű����ã��� WaterCan �� PoolWater �Ӵ�ʱ����
    public void OnWaterCanTouch()
    {
        if (touchCount < 3)
        {
            // �� PoolWater �½�����һ���׶�
            transform.localPosition = new Vector3(transform.localPosition.x, Y_Heights[touchCount], transform.localPosition.z);

            // ������ɫ
            poolMaterial.color = colors[touchCount];

            // ���Ӵ�������
            touchCount++;
        }
    }

    // ����������Ա��ⲿ�������������ˮ��״̬
    public void ResetWater()
    {
        touchCount = 0;
        transform.localPosition = new Vector3(transform.localPosition.x, 0.0134f, transform.localPosition.z);
        poolWaterRenderer.material.color = colors[0];
    }
}
