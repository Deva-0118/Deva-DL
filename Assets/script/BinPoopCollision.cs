using UnityEngine;

public class BinPoopCollision : MonoBehaviour
{
    // �������� LeafTintController
    public LeafTintController leafTintController;

    // �����ײ
    private void OnTriggerEnter(Collision collision)
    {
        // ����Ƿ������� Poop ����
        if (collision.gameObject.CompareTag("Poop"))
        {
            // ʹ Poop ��ʧ
            Destroy(collision.gameObject);

            // ���� ResetColorChange() ����
            if (leafTintController != null)
            {
                leafTintController.ResetColorChange();
            }
        }
    }
}