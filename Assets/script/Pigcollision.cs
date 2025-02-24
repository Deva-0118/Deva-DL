using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pigcollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Íæ¼Ò×²µ½ÁË£º" + collision.gameObject.name);
    }
}
