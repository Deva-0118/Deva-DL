using UnityEngine;

public class BinPoopCollision : MonoBehaviour
{
    public LeafTintController leafTintController;
    public PoolWaterController PoolWaterController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Poop"))
        {
            Destroy(other.gameObject); // 销毁 Poop

            if (leafTintController != null)
            {
                leafTintController.ResetColorChange();
            }
            if (PoolWaterController != null) // 修正了判断条件
            {
                PoolWaterController.ResetPositionChange(); // 归位 PoolWater
            }
        }
    }
}
