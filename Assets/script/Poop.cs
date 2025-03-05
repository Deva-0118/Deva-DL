using UnityEngine;

public class Poop : MonoBehaviour
{
    public LeafTintController leafController; // 用于引用 LeafController 脚本

    private void Start()
    {
 
    }

    // 确保使用 OnTriggerEnter 触发器事件
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bin")) // 确保是与 Bin 碰撞
        {
            // 调用 LeafController 的 ResetLeaf 方法
            if (leafController != null)
            {
                leafController.ResetColorChange(); // 调用 ResetLeaf 函数
            }

            // 销毁 Poop
            Destroy(gameObject);
        }
    }
}
