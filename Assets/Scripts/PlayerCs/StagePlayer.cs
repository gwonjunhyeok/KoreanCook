using UnityEngine;

public class StagePlayer : MonoBehaviour
{
    public float rotationSpeed = 90f; // 초당 회전 속도
    private Quaternion initialRotation;

    void Start()
    {
        initialRotation = transform.rotation;
    }

    void Update()
    {
        PlayerMove();
    }
    void PlayerMove()
    {
        float currentY = transform.eulerAngles.y;
        float initialY = initialRotation.eulerAngles.y;

        // 현재 회전량 (-180 ~ 180)
        float deltaY = Mathf.DeltaAngle(initialY, currentY);

        // 오른쪽 회전
        if (Input.GetKey(KeyCode.D))
        {
            if (deltaY < 90f)
            {
                transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
            }
            else
            {
                
            }
        }

        // 왼쪽 회전
        if (Input.GetKey(KeyCode.A))
        {
            if (deltaY > -90f)
            {
                transform.Rotate(0f, -rotationSpeed * Time.deltaTime, 0f);
            }
            else
            {
                
            }
        }
    }
}
