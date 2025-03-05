using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PoolWaterController : MonoBehaviour
{
    public TintController tintController;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WaterCan"))
        {
            tintController.StartColorChange();
        }
        else if (other.CompareTag("Poop"))
        {
            tintController.ResetColorChange();
        }
    }
}
