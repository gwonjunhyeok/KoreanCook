using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform target; // 플레이어 
    public float height = 10f; // y 높이
    public Vector3 offset = Vector3.zero; // 약간의 위치 오프셋

    void LateUpdate()
    {
        if (target == null) return;

        // 플레이어의 x, z 위치 + 고정된 y 높이
        Vector3 targetPosition = new Vector3(
            target.position.x + offset.x,
            height,
            target.position.z + offset.z
        );

        transform.position = targetPosition;
    }
}
