using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pigcollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("���ײ���ˣ�" + collision.gameObject.name);
    }
}
