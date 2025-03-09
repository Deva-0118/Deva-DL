using UnityEngine;

public class BinPoopCollision : MonoBehaviour
{
    public LeafTintController leafTintController;
    public PoolWaterController PoolWaterController;
    public Apple apple; // ���� Apple ʵ��

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Poop"))
        {
            Destroy(other.gameObject); // ���� Poop

            if (leafTintController != null)
            {
                leafTintController.ResetColorChange();
            }
            if (PoolWaterController != null)
            {
                PoolWaterController.ResetPositionChange(); // ��λ PoolWater
            }
            if (apple != null)
            {
                apple.RespawnApple(); // ��ԭλ���������� Apple
            }
        }
    }
}

