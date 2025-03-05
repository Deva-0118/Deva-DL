using UnityEngine;

public class BinPoopCollision : MonoBehaviour
{
    // 用于引用 LeafTintController
    public LeafTintController leafTintController;

    // 检测碰撞
    private void OnTriggerEnter(Collision collision)
    {
        // 检测是否是碰到 Poop 物体
        if (collision.gameObject.CompareTag("Poop"))
        {
            // 使 Poop 消失
            Destroy(collision.gameObject);

            // 调用 ResetColorChange() 方法
            if (leafTintController != null)
            {
                leafTintController.ResetColorChange();
            }
        }
    }
}