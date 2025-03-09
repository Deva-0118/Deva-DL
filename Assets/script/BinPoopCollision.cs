using UnityEngine;

public class BinPoopCollision : MonoBehaviour
{
    public LeafTintController leafTintController;
    public PoolWaterController PoolWaterController;
    public Apple apple; // 引用 Apple 实例

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Poop"))
        {
            Destroy(other.gameObject); // 销毁 Poop

            if (leafTintController != null)
            {
                leafTintController.ResetColorChange();
            }
            if (PoolWaterController != null)
            {
                PoolWaterController.ResetPositionChange(); // 归位 PoolWater
            }
            if (apple != null)
            {
                apple.RespawnApple(); // 在原位置重新生成 Apple
            }
        }
    }
}

