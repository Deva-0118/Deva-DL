using UnityEngine;
using TMPro;

public class ThirdLevelCounter : MonoBehaviour
{
    public int wheatCounter = 1;                // 計數 Wheat 的數字
    public int pigCounter = 1;                  // 計數 Pig 的數字
    public int appleCounter = 1;                // 計數 Apple 的數字
    private const int minCounter = 0;           // 計數器的最小值
    public TextMeshProUGUI wheatCounterText;    // 用來顯示 Wheat 計數的 TextMesh Pro UI 元件
    public TextMeshProUGUI pigCounterText;      // 用來顯示 Pig 計數的 TextMesh Pro UI 元件
    public TextMeshProUGUI appleCounterText;    // 用來顯示 Apple 計數的 TextMesh Pro UI 元件

    void Start()
    {
        UpdateCounterTexts();
    }

    void OnTriggerEnter(Collider other)
    {
        // 根據標籤執行相應操作
        switch (other.tag)
        {
            case "Wheat":
                if (wheatCounter > minCounter) wheatCounter--;
                UpdateCounterTexts();
                Destroy(other.gameObject); // 銷毀Wheat
                break;
            case "Pig":
                if (pigCounter > minCounter) pigCounter--;
                UpdateCounterTexts();
                Destroy(other.gameObject); // 銷毀Pig
                break;
            case "Apple":
                if (appleCounter > minCounter) appleCounter--;
                UpdateCounterTexts();
                Destroy(other.gameObject); // 銷毀Apple
                break;
            case "Poop":
                Destroy(other.gameObject); // 只銷毀這些物體，不影響計數器
                break;
        }
    }

    void UpdateCounterTexts()
    {
        wheatCounterText.text = wheatCounter.ToString();
        pigCounterText.text = pigCounter.ToString();
        appleCounterText.text = appleCounter.ToString();
    }
}