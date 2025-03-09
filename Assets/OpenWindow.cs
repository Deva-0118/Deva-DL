using UnityEngine;
using UnityEngine.UI;

public class OpenWindow : MonoBehaviour
{
    // 需要設定的物件
    public GameObject objectToActivate;  // 要啟用的物件
    public GameObject objectToDeactivate;  // 要禁用的物件

    // 參考按鈕
    public Button yourButton;

    void Start()
    {
        // 當按鈕被點擊時，呼叫 OpenWindow 方法
        if (yourButton != null)
        {
            yourButton.onClick.AddListener(OpenWindowMethod);
        }
    }

    // 設置物件為顯示（active）並禁用另一個物件
    public void OpenWindowMethod()
    {
        // 啟用指定的物件
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
        }

        // 禁用另一個指定的物件
        if (objectToDeactivate != null)
        {
            objectToDeactivate.SetActive(false);
        }
    }
}