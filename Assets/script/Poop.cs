using UnityEngine;

public class Poop : MonoBehaviour
{
    public LeafTintController leafController; // �������� LeafController �ű�

    private void Start()
    {
 
    }

    // ȷ��ʹ�� OnTriggerEnter �������¼�
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bin")) // ȷ������ Bin ��ײ
        {
            // ���� LeafController �� ResetLeaf ����
            if (leafController != null)
            {
                leafController.ResetColorChange(); // ���� ResetLeaf ����
            }

            // ���� Poop
            Destroy(gameObject);
        }
    }
}
