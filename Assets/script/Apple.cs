using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public void AppleDisAppear()
    {
        gameObject.SetActive(false);
    }
    public void AppleAppear()
    {
        gameObject.SetActive(true);
    }

}
