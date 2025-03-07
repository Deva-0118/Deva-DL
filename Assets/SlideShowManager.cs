using UnityEngine;
using UnityEngine.UI;

public class SlideShowManager : MonoBehaviour
{
    public Image slideImage;            // 顯示幻燈片的Image
    public Button previousButton;       // 上一張按鈕
    public Button nextButton;           // 下一張按鈕
    public Sprite[] slides;             // 存儲所有幻燈片的數組

    private int currentSlideIndex = 0;  // 當前幻燈片的索引

    void Start()
    {
        // 初始化幻燈片顯示
        UpdateSlide();

        // 設置按鈕點擊事件
        previousButton.onClick.AddListener(PreviousSlide);
        nextButton.onClick.AddListener(NextSlide);

        // 設置按鈕初始狀態
        UpdateButtonState();
    }

    // 顯示上一張幻燈片
    void PreviousSlide()
    {
        if (currentSlideIndex > 0)
        {
            currentSlideIndex--;
            UpdateSlide();
            UpdateButtonState();
        }
    }

    // 顯示下一張幻燈片
    void NextSlide()
    {
        if (currentSlideIndex < slides.Length - 1)
        {
            currentSlideIndex++;
            UpdateSlide();
            UpdateButtonState();
        }
    }

    // 更新幻燈片顯示
    void UpdateSlide()
    {
        slideImage.sprite = slides[currentSlideIndex];
    }

    // 更新按鈕狀態
    void UpdateButtonState()
    {
        previousButton.interactable = currentSlideIndex > 0; // 第一張禁用上一張按鈕
        nextButton.interactable = currentSlideIndex < slides.Length - 1; // 最後一張禁用下一張按鈕
    }
}