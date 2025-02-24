using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimationOnTrigger : MonoBehaviour
{
    public Animator animator; // 绑定 Animator 组件
    private bool hasPlayed = false; // 确保动画只播放一次

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube") && !hasPlayed) // 只有 Cube 触碰时触发
        {
            animator.SetTrigger("PlayAnimation"); // 触发动画
            hasPlayed = true; // 确保动画只播放一次
        }
    }
}

