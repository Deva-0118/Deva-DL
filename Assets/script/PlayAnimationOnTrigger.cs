using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimationOnTrigger : MonoBehaviour
{
    public Animator animator; // �� Animator ���
    private bool hasPlayed = false; // ȷ������ֻ����һ��

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube") && !hasPlayed) // ֻ�� Cube ����ʱ����
        {
            animator.SetTrigger("PlayAnimation"); // ��������
            hasPlayed = true; // ȷ������ֻ����һ��
        }
    }
}

