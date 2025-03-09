using UnityEngine;

public class BinPoopCollision : MonoBehaviour
{
    public LeafTintController leafTintController;
    public PoolWaterController PoolWaterController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Poop"))
        {
            Destroy(other.gameObject); // ���� Poop

            if (leafTintController != null)
            {
                leafTintController.ResetColorChange();
            }
            if (PoolWaterController != null) // �������ж�����
            {
                PoolWaterController.ResetPositionChange(); // ��λ PoolWater
            }
        }
    }
}
