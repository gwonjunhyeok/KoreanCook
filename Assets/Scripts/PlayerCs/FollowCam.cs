using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform target; // �÷��̾� 
    public float height = 10f; // y ����
    public Vector3 offset = Vector3.zero; // �ణ�� ��ġ ������

    void LateUpdate()
    {
        if (target == null) return;

        // �÷��̾��� x, z ��ġ + ������ y ����
        Vector3 targetPosition = new Vector3(
            target.position.x + offset.x,
            height,
            target.position.z + offset.z
        );

        transform.position = targetPosition;
    }
}
