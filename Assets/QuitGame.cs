using UnityEngine;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour
{
    // 當按下按鈕時退出遊戲
    public void Quit()
    {
        // 在編輯器模式下不會退出遊戲，只會停止播放
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        // 退出遊戲
        Application.Quit();
#endif
    }
}