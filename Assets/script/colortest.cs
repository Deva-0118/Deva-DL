using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class LeafColorController : MonoBehaviour
{
    public Material leafMaterial; // 叶子的材质
    private Color startColor = new Color(142f / 255f, 255f / 255f, 140f / 255f, 1f);
    private Color endColor = new Color(41f, 55f, 100f, 0f);
    private float transitionTime = 40f;
    private float timer = 0f;
    private bool isTransitioning = false;

    void Start()
    {
        if (leafMaterial != null)
        {
            leafMaterial.SetColor("_Tint", startColor); // 初始颜色
        }
    }

    public void StartColorChange()
    {
        if (!isTransitioning)
        {
            StartCoroutine(ChangeLeafColor());
        }
    }

    public void ResetTimer()
    {
        timer = 0f;
        isTransitioning = false;
        if (leafMaterial != null)
        {
            leafMaterial.SetColor("_Tint", startColor);
        }
        StartColorChange();
    }

    private IEnumerator ChangeLeafColor()
    {
        isTransitioning = true;
        while (timer < transitionTime)
        {
            timer += Time.deltaTime;
            float t = timer / transitionTime;
            if (leafMaterial != null)
            {
                leafMaterial.SetColor("_Tint", Color.Lerp(startColor, endColor, t));
            }
            yield return null;
        }
        isTransitioning = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PoolWater"))
        {
            StartColorChange();
        }
        else if (other.CompareTag("Poop"))
        {
            ResetTimer();
        }
    }
}
